using System;

namespace TriagemCovid19
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade;

            bool febre, tosse, sintomaRespiratorio;
            bool faltaDeAr, aumentoFrequenciaRespiratoria, dorToracica, sensacaoDesmaio;
            bool hipertensao, diabetes, outrasDoencasCronicas;
            bool doencaCronica, doencaCoronariana;
            bool situacaoGrave;
            bool possuiSinalDeAlarme, possuiFatorDeRisco;



            Console.Clear();
            Console.WriteLine("--- Triagem para COVID-19 ---");
            Console.WriteLine("Adaptado de https://www.slmandic.edu.br/tudo-sobre-coronavirus/");
            Console.WriteLine("RESULTADO ESTRITAMENTE EDUCACIONAL- PROCURE AJUDA MÉDICA \n");

            Console.Write("Qual a idade do paciente? ");

            bool idadeNumerica = Int32.TryParse(Console.ReadLine(), out idade);

            if (!idadeNumerica || idade < 0 || idade > 130)
            {
                Console.WriteLine("Idade inválida.");
                Environment.Exit(-1);
            }

            Console.WriteLine("\nResponda [S] para SIM, ou [N] para NÃO.\n");

            Console.Write("Paciente com febre? ");
            febre = Console.ReadLine().ToUpper() == "S";

            Console.Write("Paciente com tosse? ");
            tosse = Console.ReadLine().ToUpper() == "S";

            Console.Write("Paciente com outro sintoma respiratório? ");
            sintomaRespiratorio = Console.ReadLine().ToUpper() == "S";

            if (!febre && !tosse && !sintomaRespiratorio)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n* Nenhuma recomendação específica. #fiqueemcasa");
            }
            else
            {
                Console.WriteLine("\n-- Sinais de alarme --");

                Console.Write("Paciente com falta de ar? ");
                faltaDeAr = Console.ReadLine().ToUpper() == "S";

                Console.Write("Paciente com aumento de frequência respiratória? ");
                aumentoFrequenciaRespiratoria = Console.ReadLine().ToUpper() == "S";

                Console.Write("Paciente com dor torácica? ");
                dorToracica = Console.ReadLine().ToUpper() == "S";

                Console.Write("Paciente com sensação de desmaio? ");
                sensacaoDesmaio = Console.ReadLine().ToUpper() == "S";

                possuiSinalDeAlarme = faltaDeAr
                    || aumentoFrequenciaRespiratoria
                    || dorToracica
                    || sensacaoDesmaio;

                if (idade < 18)
                {
                    Console.WriteLine("\n-- Fatores de risco para menores --");

                    Console.Write("Paciente com hipertensão arterial sistêmica? ");
                    hipertensao = Console.ReadLine().ToUpper() == "S";

                    Console.Write("Paciente com diabetes melito? ");
                    diabetes = Console.ReadLine().ToUpper() == "S";

                    Console.Write("Paciente com outras doenças crônicas? ");
                    outrasDoencasCronicas = Console.ReadLine().ToUpper() == "S";

                    possuiFatorDeRisco = hipertensao || diabetes || outrasDoencasCronicas;
                }
                else
                {
                    Console.WriteLine("\n-- Fatores de risco para maiores --");

                    Console.Write("Paciente com doença coronariana prévia? ");
                    doencaCoronariana = Console.ReadLine().ToUpper() == "S";

                    Console.Write("Paciente com doença crônica descompensada? ");
                    doencaCronica = Console.ReadLine().ToUpper() == "S";

                    possuiFatorDeRisco = (idade > 65)
                        || aumentoFrequenciaRespiratoria
                        || doencaCoronariana
                        || doencaCronica;
                }

                if (possuiSinalDeAlarme || possuiFatorDeRisco)
                {
                    Console.WriteLine("\n-- Situação --");

                    Console.Write("Paciente com situação grave? ");
                    situacaoGrave = Console.ReadLine().ToUpper() == "S";

                    if (situacaoGrave)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n* Encaminhar ambulância para o local.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n* Encaminhar para o sistema de saúde.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n* Recomendar isolamento domiciliar.");
                }

            }

            Console.ResetColor();
            Console.Write("\nObrigado!");
        }
    }
}