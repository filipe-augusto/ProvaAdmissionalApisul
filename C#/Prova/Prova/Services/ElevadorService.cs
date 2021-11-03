using Prova.Shared;
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Services
{
    class ElevadorService : IElevadorService
    {
        public List<Votacao> ListaVotacoes { get; set; }
        public int aux = 0;
        public List<int> andarMenosUtilizado()
        {
            var resultado = from votacao in ListaVotacoes group votacao by votacao.andar;
            List<int> Listamenores = new List<int>();
            {

                foreach (var grupo in resultado.OrderBy(x => x.Key))
                {
                    //Console.WriteLine($"ANDAR: {grupo.Key} - QUANTIDADE: {grupo.Count()}");
                    if (aux == 0)
                    {
                        aux = grupo.Count();
                        Listamenores.Add(grupo.Key);
                    }
                    else
                    {
                        if (grupo.Count() <= aux)
                        {
                           
                            if (grupo.Count() == aux)
                            {
                                Listamenores.Add(grupo.Key);
                            }
                            else
                            {
                                aux = grupo.Count();
                                Listamenores.Clear();
                                Listamenores.Add(grupo.Key);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nAndares menos utilizado: ");
            aux = 0;
            return Listamenores;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var resultado = from votacao in ListaVotacoes group votacao by votacao.elevador;
            List<char> ListaElevadoresMaisFrequentados = new List<char>();
            if (resultado is not null)
            {
                foreach (var grupo in resultado)
                {
                 //   Console.WriteLine($"ELEVADOR: {grupo.Key} - FREQUENTADO: {grupo.Count()} ");
                    if (aux == 0)
                    {
                        aux = grupo.Count();
                        ListaElevadoresMaisFrequentados.Add(grupo.Key);
                    }
                    else
                    {
                        if (grupo.Count() >= aux)
                        {
                            //  aux = grupo.Count();
                            if (grupo.Count() == aux)
                            {
                                ListaElevadoresMaisFrequentados.Add(grupo.Key);
                            }
                            else
                            {
                                aux = (int)grupo.Count();
                                ListaElevadoresMaisFrequentados.Clear();
                                ListaElevadoresMaisFrequentados.Add(grupo.Key);
                            }
                        }
                    }
                }
                aux = 0;
                return ListaElevadoresMaisFrequentados;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<char> elevadorMenosFrequentado()
        {
            var resultado = from votacao in ListaVotacoes group votacao by votacao.elevador;
            List<char> ListaElevadoresMaisFrequentados = new List<char>();
            if (resultado is not null)
            {
                foreach (var grupo in resultado)
                {
                 //   Console.WriteLine($"ELEVADOR: {grupo.Key} - FREQUENTADO: {grupo.Count()} ");
                    if (aux == 0)
                    {
                        aux = (int)grupo.Count();
                        ListaElevadoresMaisFrequentados.Add(grupo.Key);
                    }
                    else
                    {
                        if (grupo.Count() <= aux)
                        {

                            if (grupo.Count() == aux)
                            {
                                ListaElevadoresMaisFrequentados.Add(grupo.Key);
                            }
                            else
                            {
                                aux = (int)grupo.Count();
                                ListaElevadoresMaisFrequentados.Clear();
                                ListaElevadoresMaisFrequentados.Add(grupo.Key);
                            }
                        }
                    }
                }
                aux = 0;
                return ListaElevadoresMaisFrequentados;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public float percentualDeUsoElevadorA()
        {
            if (ListaVotacoes is not null)
            {
                
               // var resultado = 
                return (float)(ListaVotacoes.Where(x => x.elevador == 'A').Count() * 100.00) /
                       ListaVotacoes.Select(x => x.elevador).Count();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public float percentualDeUsoElevadorB()
        {
            if (ListaVotacoes is not null)
            {

                return (float)(ListaVotacoes.Where(x => x.elevador == 'B').Count() * 100.00) /
                       ListaVotacoes.Select(x => x.elevador).Count();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public float percentualDeUsoElevadorC()
        {
            if (ListaVotacoes is not null)
            {

                return (float)(ListaVotacoes.Where(x => x.elevador == 'C').Count() * 100.00) /
                       ListaVotacoes.Select(x => x.elevador).Count();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public float percentualDeUsoElevadorD()
        {
            if (ListaVotacoes is not null)
            {

                return (float)(ListaVotacoes.Where(x => x.elevador == 'D').Count() * 100.00) /
                       ListaVotacoes.Select(x => x.elevador).Count();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public float percentualDeUsoElevadorE()
        {
            if (ListaVotacoes is not null)
            {

                return (float)(ListaVotacoes.Where(x => x.elevador == 'E').Count() * 100.00) /
                       ListaVotacoes.Select(x => x.elevador).Count();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadoraisFrequentado = elevadorMaisFrequentado();
            var resultado = 
                from votacao in ListaVotacoes.Where(x => x.elevador == elevadoraisFrequentado.FirstOrDefault()) group votacao by votacao.turno;
            List<char> ListaPeriodoMaiorFluxoElevadorMaisFrequentado = new List<char>();

            foreach (var grupo in resultado)
            {
              //  Console.WriteLine($"PERIODO: {grupo.Key} - FREQUENTADO: {grupo.Count()} ");
       
                if (aux == 0)
                {
                    aux = (int)grupo.Count();
                    ListaPeriodoMaiorFluxoElevadorMaisFrequentado.Add(grupo.Key);
                }
                else
                {
                    if (grupo.Count() >= aux)
                    {

                        if (grupo.Count() == aux)
                        {
                            ListaPeriodoMaiorFluxoElevadorMaisFrequentado.Add(grupo.Key);
                        }
                        else
                        {
                            aux = (int)grupo.Count();
                            ListaPeriodoMaiorFluxoElevadorMaisFrequentado.Clear();
                            ListaPeriodoMaiorFluxoElevadorMaisFrequentado.Add(grupo.Key);
                        }
                    }
                }

            }
            aux = 0;
            return ListaPeriodoMaiorFluxoElevadorMaisFrequentado;

            throw new NotImplementedException();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var resultado =
                from votacao in ListaVotacoes group votacao by votacao.turno;
            List<char> ListaPeriodoMaiorUtilizacaoConjuntoElevadores = new List<char>();
           
            foreach (var grupo in resultado)
            {
               // Console.WriteLine($"PERIODO: {grupo.Key} - FREQUENTADO: {grupo.Count()} ");
       
                if (aux == 0)
                {
                    aux = (int)grupo.Count();
                    ListaPeriodoMaiorUtilizacaoConjuntoElevadores.Add(grupo.Key);
                }
                else
                {
                    if (grupo.Count() >= aux)
                    {

                        if (grupo.Count() == aux)
                        {
                            ListaPeriodoMaiorUtilizacaoConjuntoElevadores.Add(grupo.Key);
                        }
                        else
                        {
                            aux = (int)grupo.Count();
                            ListaPeriodoMaiorUtilizacaoConjuntoElevadores.Clear();
                            ListaPeriodoMaiorUtilizacaoConjuntoElevadores.Add(grupo.Key);
                        }
                    }
                }

            }
            aux = 0;
            return ListaPeriodoMaiorUtilizacaoConjuntoElevadores;

            throw new NotImplementedException();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {

            List<char> ListaElevadorMenosFrequentado = elevadorMenosFrequentado();
            List<Votacao> listaAux = new List<Votacao>();

            foreach (var item in ListaVotacoes)
            {
                if (ListaElevadorMenosFrequentado.Contains(item.elevador))
                {
                listaAux.Add(item);
                }
            }
            var resultado =
              from votacao in listaAux group votacao by votacao.turno;
          
            List<char> ListaPeriodoMenorFluxoElevadorMenosFrequentado = new List<char>();
            foreach (var grupo in resultado)
            {
              // Console.WriteLine($"PERIODO: {grupo.Key} - FREQUENTADO: {grupo.Count()} ");

                if (aux == 0)
                {
                    aux = (int)grupo.Count();
                    ListaPeriodoMenorFluxoElevadorMenosFrequentado.Add(grupo.Key);
                }
                else
                {
                    if (grupo.Count() <= aux)
                    {

                        if (grupo.Count() == aux)
                        {
                            ListaPeriodoMenorFluxoElevadorMenosFrequentado.Add(grupo.Key);
                        }
                        else
                        {
                            aux = (int)grupo.Count();
                            ListaPeriodoMenorFluxoElevadorMenosFrequentado.Clear();
                            ListaPeriodoMenorFluxoElevadorMenosFrequentado.Add(grupo.Key);
                        }
                    }
                }

            }
            aux = 0;
            return ListaPeriodoMenorFluxoElevadorMenosFrequentado;

            throw new NotImplementedException();
        }
    }
}
