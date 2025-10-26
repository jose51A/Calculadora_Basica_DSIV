using System;
using System.Globalization;
using System.Windows.Forms;

namespace CalculadoraBasica
{
    public partial class CalculatorForm : Form
    {
        // Estado para próximos módulos:
        private decimal? _operando1 = null;
        private string? _operador = null; // "+", "-", "×", "÷"
        private bool _nuevaEntrada = true; // si true, el siguiente dígito reemplaza el display
        private bool _despuesDeIgual = false; // si true, limpiar al ingresar número
        private readonly char _sepDecimal;
        // Indica si el último botón pulsado fue un operador
        private bool _ultimoFueOperador = false;

        // Estado visual / timer para mensajes
        private readonly System.Windows.Forms.Timer _statusTimer;
        private int _statusTimeoutMs = 3000; // ms por defecto para los mensajes

        public CalculatorForm()
        {
            // Determinar separador decimal antes de usarlo
            _sepDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            InitializeComponent();

            // Ajustes post-inicialización de controles
            KeyPreview = true; // para capturar teclado luego
            btnPunto.Text = _sepDecimal.ToString();

            // Timer de estado
            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Tick += StatusTimer_Tick;
            _statusTimer.Interval = _statusTimeoutMs;

            // Display inicial
            txtDisplay.Text = "0";

            // Mensaje inicial
            ShowStatus("Listo.", 1000, false);
        }

        // Helpers privados
        private void BeginNewEntryIfNeeded()
        {
            // Si venimos de "=", reiniciar todo para nueva operación
            if (_despuesDeIgual)
            {
                _operando1 = null;
                _operador = null;
                _despuesDeIgual = false;
                txtDisplay.Text = "0";
                ShowStatus("Listo.", 800, false);
            }

            // Si se seleccionó un operador y esperamos el siguiente número
            if (_nuevaEntrada)
            {
                txtDisplay.Text = "0";
                _nuevaEntrada = false;
            }
        }

        private static int CountDigits(string s)
        {
            int count = 0;
            foreach (char c in s)
                if (char.IsDigit(c)) count++;
            return count;
        }

        private void AppendDigit(char d)
        {
            BeginNewEntryIfNeeded();

            string current = txtDisplay.Text;

            // No permitir más de 12 dígitos (sin contar separador)
            int digits = CountDigits(current);
            if (digits >= 12)
            {
                ShowStatus("Máximo 12 dígitos.", 2500, false);
                return;
            }

            // Manejo de cero inicial: si es "0" y llega otro "0", conservar "0"
            if (current == "0")
            {
                if (d == '0')
                {
                    // No cambia nada
                    return;
                }
                // Si es "0" y llega 1-9, reemplazar
                txtDisplay.Text = d.ToString();
                return;
            }

            // Agregar dígito normal
            txtDisplay.Text = current + d;
        }

        private void AppendDecimalSeparator()
        {
            BeginNewEntryIfNeeded();

            string current = txtDisplay.Text;

            // Si ya tiene separador, ignorar
            if (current.IndexOf(_sepDecimal) >= 0)
                return;

            // No comenzar con punto: si está vacío o "0", convertir a "0,"
            if (string.IsNullOrWhiteSpace(current) || current == "0")
            {
                txtDisplay.Text = "0" + _sepDecimal;
                return;
            }

            // Agregar separador
            txtDisplay.Text = current + _sepDecimal;
        }

        private bool TryGetDisplayValue(out decimal value)
        {
            return decimal.TryParse(txtDisplay.Text, System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.CurrentCulture, out value);
        }

        private bool HasMeaningfulInput()
        {
            // Consideramos entrada significativa si el display no es simplemente "0"
            // Nota: si el usuario puso "0," o "0." ya es válido (fue una acción explícita).
            return txtDisplay.Text != "0";
        }

        private void ResetAll(string estado = "Listo.")
        {
            _operando1 = null;
            _operador = null;
            _nuevaEntrada = true;
            _despuesDeIgual = false;
            txtDisplay.Text = "0";
            _ultimoFueOperador = false;
            ShowStatus(estado, 1500, false);
        }

        private void SetError(string mensaje)
        {
            // Mostrar error en rojo y dejar persistente hasta que el usuario presione C
            ShowStatus("Error: " + mensaje, 0, true);
            // Reiniciar estado interno para evitar operaciones posteriores hasta limpiar
            _operando1 = null;
            _operador = null;
            _nuevaEntrada = true;
            _despuesDeIgual = false;
            _ultimoFueOperador = false;
            txtDisplay.Text = "0";
        }

        private string FormatNumber(decimal value)
        {
            var ci = System.Globalization.CultureInfo.CurrentCulture;
            string s = value.ToString(ci);

            // Trim ceros a la derecha si hay separador decimal
            if (s.IndexOf(ci.NumberFormat.NumberDecimalSeparator, StringComparison.Ordinal) >= 0)
            {
                s = s.TrimEnd('0');
                if (s.EndsWith(ci.NumberFormat.NumberDecimalSeparator))
                    s = s.Substring(0, s.Length - ci.NumberFormat.NumberDecimalSeparator.Length);
                if (s.Length == 0)
                    s = "0";
            }

            // Evitar desbordes visuales extremos (el TextBox ya tiene MaxLength=20)
            if (s.Length > 20)
                s = s.Substring(0, 20);

            return s;
        }

        private bool HasSecondOperandReady()
        {
            // Segundo operando está listo si NO estamos en nuevaEntrada
            // (es decir, el usuario tecleó algo después de elegir operador)
            return !_nuevaEntrada;
        }

        private decimal ApplyOperation(decimal a, string op, decimal b)
        {
            return op switch
            {
                "+" => a + b,
                "−" or "-" => a - b,
                "×" or "*" or "x" or "X" => a * b,
                "÷" or "/" => b == 0m ? throw new DivideByZeroException() : a / b,
                _ => throw new InvalidOperationException("Operador no reconocido.")
            };
        }

        private void TriggerOperador(string symbol)
        {
            // Reutilizamos la misma lógica que los botones creando un Button temporal
            using var temp = new Button { Text = symbol };
            OperadorButton_Click(temp, EventArgs.Empty);
        }

        private void StatusTimer_Tick(object? sender, EventArgs e)
        {
            _statusTimer.Stop();
            lblEstado.Text = "Listo.";
            lblEstado.ForeColor = System.Drawing.Color.Black;
        }

        private void ShowStatus(string mensaje, int ms = 3000, bool isError = false)
        {
            lblEstado.Text = mensaje;
            lblEstado.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Black;

            // Si tiempo <= 0, dejar persistente (no iniciar timer)
            if (ms <= 0)
            {
                _statusTimer.Stop();
                return;
            }

            _statusTimer.Interval = ms;
            _statusTimer.Stop();
            _statusTimer.Start();
        }

        private static string NormalizeOperator(string op)
        {
            return op switch
            {
                "/" => "÷",
                "*" or "x" or "X" => "×",
                "-" => "−",
                "+" => "+",
                "÷" or "×" or "−" => op,
                _ => op
            };
        }

        // ——— Eventos ———

        // Números 0–9
        private void DigitButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button b && b.Text.Length == 1 && char.IsDigit(b.Text[0]))
            {
                AppendDigit(b.Text[0]);
                _ultimoFueOperador = false;
            }
        }

        // Punto decimal
        private void PuntoButton_Click(object? sender, EventArgs e)
        {
            AppendDecimalSeparator();
            _ultimoFueOperador = false;
        }

        // Operadores +, −, ×, ÷
        private void OperadorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button b || string.IsNullOrWhiteSpace(b.Text))
                return;

            // Normalizamos (si quieres aceptar "/" o "x", asegúrate de tener NormalizeOperator o hazlo inline)
            string op = b.Text;
            // Si usas NormalizeOperator, úsalo:
            // op = NormalizeOperator(b.Text);

            // Caso: venimos de "=" -> tomar resultado actual como operando1
            if (_despuesDeIgual)
            {
                if (TryGetDisplayValue(out var actual))
                {
                    _operando1 = actual;
                    _operador = op;
                    _nuevaEntrada = true;
                    _despuesDeIgual = false;
                    ShowStatus($"{_operando1?.ToString(System.Globalization.CultureInfo.CurrentCulture)} {op}", 2000, false);
                    _ultimoFueOperador = true;
                }
                return;
            }

            // Si no hay entrada significativa y no hay operando1, ignorar
            if (!HasMeaningfulInput() && _operando1 is null)
            {
                _ultimoFueOperador = true; // igual marcar que pulsó operador (por si luego cambia)
                return;
            }

            // Si aún no teníamos operando1, capturarlo ahora
            if (_operando1 is null)
            {
                if (!TryGetDisplayValue(out var valor))
                {
                    ShowStatus("Entrada inválida.", 2000, false);
                    _ultimoFueOperador = true;
                    return;
                }

                _operando1 = valor;
                _operador = op;
                _nuevaEntrada = true;
                ShowStatus($"{_operando1?.ToString(System.Globalization.CultureInfo.CurrentCulture)} {op}", 2000, false);
                _ultimoFueOperador = true;
                return;
            }

            // Si ya había un operador pendiente...
            if (_operador is not null)
            {
                // Caso normal: el usuario aún NO ingresó el segundo operando => cambiar operador (sin evaluar)
                if (!HasSecondOperandReady())
                {
                    _operador = op;
                    ShowStatus($"{_operando1?.ToString(System.Globalization.CultureInfo.CurrentCulture)} {op}", 2000, false);
                    _ultimoFueOperador = true;
                    return;
                }

                // Si aquí, sí hay segundo operando (se tecleó algo): evaluar primero y luego establecer nuevo operador
                if (!TryGetDisplayValue(out var operando2))
                {
                    SetError("Entrada inválida.");
                    return;
                }

                try
                {
                    var prevOp = _operador!; // operador que se aplica ahora
                    var resultado = ApplyOperation(_operando1.Value, prevOp, operando2);
                    string sResultado = FormatNumber(resultado);
                    txtDisplay.Text = sResultado;

                    var ci = System.Globalization.CultureInfo.CurrentCulture;
                    string aTxt = _operando1.Value.ToString(ci);
                    string bTxt = operando2.ToString(ci);

                    // Preparar para la siguiente operación con el nuevo operador
                    _operando1 = resultado;
                    _operador = op;
                    _nuevaEntrada = true;
                    _despuesDeIgual = false;

                    ShowStatus($"{aTxt} {prevOp} {bTxt} = {sResultado}", 1500, false);
                    _ultimoFueOperador = true;
                }
                catch (DivideByZeroException)
                {
                    SetError("No se puede dividir entre cero.");
                }
                catch (OverflowException)
                {
                    SetError("Resultado fuera de rango.");
                }
                catch (Exception)
                {
                    SetError("Resultado inválido.");
                }
                return;
            }

            // Si no había operador (caso borde), simplemente guardar el nuevo operador
            _operador = op;
            _nuevaEntrada = true;
            ShowStatus($"{_operando1?.ToString(System.Globalization.CultureInfo.CurrentCulture)} {op}", 2000, false);
            _ultimoFueOperador = true;
        }

        // Igual =
        private void IgualButton_Click(object? sender, EventArgs e)
        {
            // Si no hay operador pendiente, no hay nada que calcular
            if (_operador is null || _operando1 is null)
                return;

            // Si el segundo operando no fue ingresado (pulsaron = sin teclear número), ignorar
            if (!HasSecondOperandReady())
                return;

            if (!TryGetDisplayValue(out var operando2))
            {
                SetError("Entrada inválida.");
                return;
            }

            try
            {
                var resultado = ApplyOperation(_operando1.Value, _operador, operando2);

                // decimal no tiene NaN/Infinity; por seguridad, validamos rangos extremos con try-catch
                string sResultado = FormatNumber(resultado);
                txtDisplay.Text = sResultado;

                // Estado y banderas
                var ci = System.Globalization.CultureInfo.CurrentCulture;
                string aTxt = _operando1.Value.ToString(ci);
                string bTxt = operando2.ToString(ci);
                ShowStatus($"{aTxt} {_operador} {bTxt} = {sResultado}", 0, false); // persistente para que el usuario vea el resultado

                // Dejar listo para nueva entrada o encadenar operador
                _operando1 = resultado; // permite encadenar si se pulsa un operador
                _operador = null;
                _nuevaEntrada = true;
                _despuesDeIgual = true; // si se teclea un dígito, comenzará una nueva operación
            }
            catch (DivideByZeroException)
            {
                SetError("No se puede dividir entre cero.");
            }
            catch (OverflowException)
            {
                SetError("Resultado fuera de rango.");
            }
            catch (Exception)
            {
                SetError("Resultado inválido.");
            }
        }

        // Borrar un carácter ←
        private void BackButton_Click(object? sender, EventArgs e)
        {
            string current = txtDisplay.Text;

            // Si ya está "0", no hay nada que borrar
            if (current == "0" || string.IsNullOrEmpty(current))
                return;

            // Si venimos de "=", permitir editar el resultado: salir de ese estado
            _despuesDeIgual = false;
            _nuevaEntrada = false;

            // Eliminar el último carácter
            current = current.Substring(0, current.Length - 1);

            // Si quedó vacío o solo "-", volver a "0"
            if (string.IsNullOrEmpty(current) || current == "-")
                current = "0";

            txtDisplay.Text = current;
            ShowStatus("Listo.", 800, false);
        }

        // Limpiar todo C
        private void ClearButton_Click(object? sender, EventArgs e)
        {
            ResetAll();
        }

        // Teclado (Módulo 6)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Extraer solo la tecla (sin modificadores)
            Keys key = keyData & Keys.KeyCode;

            // Dígitos (fila superior y numpad)
            switch (key)
            {
                case Keys.D0: case Keys.NumPad0: AppendDigit('0'); return true;
                case Keys.D1: case Keys.NumPad1: AppendDigit('1'); return true;
                case Keys.D2: case Keys.NumPad2: AppendDigit('2'); return true;
                case Keys.D3: case Keys.NumPad3: AppendDigit('3'); return true;
                case Keys.D4: case Keys.NumPad4: AppendDigit('4'); return true;
                case Keys.D5: case Keys.NumPad5: AppendDigit('5'); return true;
                case Keys.D6: case Keys.NumPad6: AppendDigit('6'); return true;
                case Keys.D7: case Keys.NumPad7: AppendDigit('7'); return true;
                case Keys.D8: case Keys.NumPad8: AppendDigit('8'); return true;
                case Keys.D9: case Keys.NumPad9: AppendDigit('9'); return true;
            }

            // Separador decimal (numpad y teclas . ,)
            if (key == Keys.Decimal || key == Keys.Oemcomma || key == Keys.OemPeriod)
            {
                AppendDecimalSeparator();
                return true;
            }

            // Operadores (+ − × ÷)
            switch (key)
            {
                case Keys.Add:
                case Keys.Oemplus:      // '+' en algunos teclados
                    TriggerOperador("+");
                    return true;

                case Keys.Subtract:
                case Keys.OemMinus:
                    TriggerOperador("−");
                    return true;

                case Keys.Multiply:
                    TriggerOperador("×");
                    return true;

                case Keys.Divide:
                case Keys.OemQuestion:  // '/' en algunos teclados
                    TriggerOperador("÷");
                    return true;
            }

            // Acciones especiales
            switch (key)
            {
                case Keys.Enter:
                    IgualButton_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Escape:
                    ClearButton_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Back:
                    BackButton_Click(this, EventArgs.Empty);
                    return true;
            }

            // Bloquear el resto (evitar que suene beep o se intente escribir en el TextBox readonly)
            return true;
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }
    }
}