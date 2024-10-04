using System;
using System.IO;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Favor informar os caminhos na linha de comando.");
            return;
        }

        string arquivoOrigem   = args[0];
        string arquivoDestino  = arquivoOrigem; //(args.Length < 2) ? arquivoOrigem : args[1];
        string nomeColunaDest  = args[1];
        string valorColunaDest = args[2];

        if (!File.Exists(arquivoOrigem))
        {
            Console.WriteLine("Arquivo de origem não existe.");
            return;
        }

        string[] linhasOrigem = File.ReadAllLines(arquivoOrigem);
        int maiorLarguraLinha = obterMaiorLarguraLinha(linhasOrigem);
        int espacoExtra = 3;
        
        StringBuilder conteudoNovoSb = new StringBuilder();

        for (int i = 0; i < linhasOrigem.Length; i++)
        {
            string linhaLimpa = limparString(linhasOrigem[i]);
            string conteudoNovaColuna = (i > 0) ? valorColunaDest : nomeColunaDest;
            conteudoNovoSb.Append(linhaLimpa.PadRight(maiorLarguraLinha + espacoExtra));
            conteudoNovoSb.Append(conteudoNovaColuna);
            conteudoNovoSb.Append('\n');
        }
        
        File.WriteAllText(arquivoDestino, conteudoNovoSb.ToString());
        
        Console.WriteLine("Operação concluída.");
        Console.ReadKey();
    }

    private static int obterMaiorLarguraLinha(in string[] linhas)
    {
        int maiorLarguraLinha = int.MinValue;
        foreach (string linha in linhas)
        {
            string linhaLimpa = limparString(linha);
            if (linhaLimpa.Length > maiorLarguraLinha)
                maiorLarguraLinha = linhaLimpa.Length;
        }
        return maiorLarguraLinha;
    }

    private static string limparString(string str)
    {
        return str.TrimEnd().Replace("\t", "    ");
    }
}
