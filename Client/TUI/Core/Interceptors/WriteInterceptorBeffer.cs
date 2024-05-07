using System.Text;

namespace Client.TUI.Core.Interceptors;
public class WriteInterceptorBuffer
: TextWriter
{
    public override Encoding Encoding => Console.Out.Encoding;

    public override void Write(string value)
    {
        // Intercepta a saída antes de escrever no console
        // Faça o que quiser com o valor aqui
        /* string modifiedValue = "Texto modificado: " + value; */
        /* base.Write(modifiedValue); */
        /* Console.Out.Write(modifiedValue); */
    }
}
