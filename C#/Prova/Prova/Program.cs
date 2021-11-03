using Newtonsoft.Json;
using Prova.Services;
using Prova.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Prova
{

    class Program
    {
        static List<Votacao> Votacoes = new List<Votacao>();
        static ElevadorService service;
        static void Main(string[] args)
        {
            try
            {
                //arquivo json ta na pasta bin
                string path = Directory.GetCurrentDirectory() + @"\Exemplo.json";
                PassarParaList(path);

                if (Votacoes.Count > 0)
                {
                    service = new ElevadorService() { ListaVotacoes = Votacoes };
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("========================================================");
                Console.Write("a.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Quais são os andares menos utilizados pelos usuários");
                foreach (var item in service.andarMenosUtilizado().OrderBy(x => x))
                {
                    Console.WriteLine("Andar: " + item);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("========================================================");
                Console.Write("b.");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("Qual é o elevador mais frequentado e o período que se encontra maior fluxo\n");
                foreach (var item in service.elevadorMaisFrequentado())
                {
                    Console.WriteLine("Elevador mais frequentado: " + item);
                }
                foreach (var item in service.periodoMaiorFluxoElevadorMaisFrequentado())
                {
                    Console.WriteLine("Período com maior Fluxo do elevador mais frequentado: " + item);
                }


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("========================================================");
                Console.Write("c.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Qual é o elevador menos frequentado e o período que se encontra menor fluxo\n");
                foreach (var item in service.elevadorMenosFrequentado())
                {
                    Console.WriteLine("Elevador menos frequentado: " + item);
                }
                foreach (var item in service.periodoMenorFluxoElevadorMenosFrequentado())
                {
                    Console.WriteLine("periodo com menor fluxo dos elevadores menos frequentados: " + item);
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("========================================================");
                Console.Write("d.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Qual o período de maior de  utilização dos conjunto de elevadores\n");
                foreach (var item in service.periodoMaiorUtilizacaoConjuntoElevadores())
                {
                    Console.WriteLine("Periodo maior de utilização: " + item);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("========================================================");
                Console.Write("e.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Qual o percentual de uso de cada elevador com relação a todos os serviços prestados\n");
                Console.WriteLine("Uso do Elevador A: " + service.percentualDeUsoElevadorA().ToString("F2") + "%");
                Console.WriteLine("Uso do Elevador B: " + service.percentualDeUsoElevadorB().ToString("F2") + "%");
                Console.WriteLine("Uso do Elevador C: " + service.percentualDeUsoElevadorC().ToString("F2") + "%");
                Console.WriteLine("Uso do Elevador D: " + service.percentualDeUsoElevadorD().ToString("F2") + "%");
                Console.WriteLine("Uso do Elevador E: " + service.percentualDeUsoElevadorE().ToString("F2") + "%");

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        static void PassarParaList(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Arquivo não encontrado ");
            }
            else
            {

                using (StreamReader r = new StreamReader(arquivo))
                {
                    string json = r.ReadToEnd();

                    Votacoes = JsonConvert.DeserializeObject<List<Votacao>>(json);
                }
            }
        }
    }
}
