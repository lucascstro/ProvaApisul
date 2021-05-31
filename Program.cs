using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjeProvaAdimissionalApisul.Services;
using ProvaAdimissionalApisul.Services;
using ProvaAdmissionalCSharpApisul;

namespace ProjeProvaAdimissionalApisul
{
    class Program
    {
        //constutores
        static List<Voto> votos = new List<Voto>();
        static IElevadorService _elevadorService = new UsaElevadorService();

        //carrega dados do json
        static public void carregaData()
        {
            try
            {   //string caminho do  json
                string jsonData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"/input.json");
                //var q recebe json deserializado
                var dados = JsonConvert.DeserializeObject<List<RegistroVotacao>>(jsonData);
                //adiciona na lista Voto os dados do json
                foreach (var item in dados)
                {
                    votos.Add(new Voto() { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Turno });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ërro ao carregar arquivo, não será possível seguir com as operações!");
                Console.WriteLine("Descrição do erro: " + e.ToString() + "\n\n");
            }
        }
        //impressoes desejadas 
        static public void chamadaImpressao(int op)
        {
            carregaData();

            try
            {
                //impressao todos
                if (op == 1)
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("Elevador mais frequentado pelos usuários é: " + _elevadorService.elevadorMaisFrequentado(votos)[0].ToString() + " e o segundo mais frequentado é: " + _elevadorService.elevadorMaisFrequentado(votos)[1].ToString());
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("Elevador menos frequentado pelos usuários é: " + _elevadorService.elevadorMenosFrequentado(votos)[0].ToString() + " e o segundo menos frequentado é: " + _elevadorService.elevadorMenosFrequentado(votos)[1].ToString());
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.Write("O andar que possui a menor frequencia de usuários é : ");
                    for (int i = 0; i < _elevadorService.andarMenosUtilizado(votos).Count; i++)
                    {
                        Console.Write(_elevadorService.andarMenosUtilizado(votos)[i].ToString());
                        if (i < _elevadorService.andarMenosUtilizado(votos).Count - 1)
                        {
                            Console.Write(" e ");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O periodo com maior utilizacao dos elevadores pelos usuários é: " + _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado(votos)[0]);
                    Console.WriteLine("Neste periodo, o elevador mais utilizado pelos usuários é: " + _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado(votos)[1]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O periodo com menor utilizacao dos elevadores pelos usuários é: " + _elevadorService.periodoMenorFluxoElevadorMenosFrequentado(votos)[0]);
                    Console.WriteLine("Neste periodo, o elevador menos utilizado pelos usuários é: " + _elevadorService.periodoMenorFluxoElevadorMenosFrequentado(votos)[1]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O elevador mais utilizado pelos usuários é: " + _elevadorService.elevadorMaisFrequentadoPeriodoMaiorFluxo(votos)[0]);
                    Console.WriteLine("Neste elevador, o periodo mais utilizado pelos usuários é: " + _elevadorService.elevadorMaisFrequentadoPeriodoMaiorFluxo(votos)[1]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O elevador menos utilizado pelos usuários é: " + _elevadorService.elevadorMenosFrequentadoPeriodoMenorFluxo(votos)[0]);
                    Console.WriteLine("Neste elevador, o periodo menos utilizado pelos usuários é: " + _elevadorService.elevadorMenosFrequentadoPeriodoMenorFluxo(votos)[1]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O maior periodo de Utilização é em conjunto pelos usuários é: " + _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores(votos)[0]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O percentual de utilizacao do elevador A é: " + _elevadorService.percentualDeUsoElevadorA(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador B é: " + _elevadorService.percentualDeUsoElevadorB(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador C é: " + _elevadorService.percentualDeUsoElevadorC(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador D é: " + _elevadorService.percentualDeUsoElevadorD(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador E é: " + _elevadorService.percentualDeUsoElevadorE(votos) + "%");
                    Console.WriteLine("------------------------------------------------------------------------");
                    controleMain();

                }
                //impressao pedidos teste
                else if (op == 2)
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.Write("O andar que possui a menor frequencia de usuários é: ");
                    for (int i = 0; i < _elevadorService.andarMenosUtilizado(votos).Count; i++)
                    {
                        Console.Write(_elevadorService.andarMenosUtilizado(votos)[i].ToString());
                        if (i < _elevadorService.andarMenosUtilizado(votos).Count - 1)
                        {
                            Console.Write(" e ");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O elevador mais utilizado pelos usuários é: " + _elevadorService.elevadorMaisFrequentadoPeriodoMaiorFluxo(votos)[0]);
                    Console.WriteLine("Neste elevador, o periodo mais utilizado pelos usuários é: " + _elevadorService.elevadorMaisFrequentadoPeriodoMaiorFluxo(votos)[1]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O elevador menos utilizado pelos usuários é: " + _elevadorService.elevadorMenosFrequentadoPeriodoMenorFluxo(votos)[0]);
                    Console.WriteLine("Neste elevador, o periodo menos utilizado pelos usuários é: " + _elevadorService.elevadorMenosFrequentadoPeriodoMenorFluxo(votos)[1]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O maior periodo de Utilização pelos usuários em conjunto é: " + _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores(votos)[0]);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("O percentual de utilizacao do elevador A é: " + _elevadorService.percentualDeUsoElevadorA(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador B é: " + _elevadorService.percentualDeUsoElevadorB(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador C é: " + _elevadorService.percentualDeUsoElevadorC(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador D é: " + _elevadorService.percentualDeUsoElevadorD(votos) + "%");
                    Console.WriteLine("O percentual de utilizacao do elevador E é: " + _elevadorService.percentualDeUsoElevadorE(votos) + "%");
                    Console.WriteLine("------------------------------------------------------------------------");
                    controleMain();
                }
                //limpar console
                else if (op == 3)
                {
                    Console.Clear();
                    controleMain();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Ocorreu algo inesperado, favor contatar o Lucas!");
                Console.WriteLine("Descrição do Erro: " + e + "\n\n");
                Console.WriteLine("------------------------------------------------------------------------");
                Console.ReadKey();
            }
        }
        //controle do menu
        static public void controleMain()
        {            
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Olá, Selecione a forma de impressão desejada: ");
            Console.WriteLine("1 - Imprimir todos os retornos de IElevadorService");
            Console.WriteLine("2 - Imprimir somente retornos listados no case do teste");
            Console.WriteLine("3 - Para limpar o console");
            Console.WriteLine("------------------------------------------------------------------------");
            int op = Convert.ToInt32(Console.ReadLine());
            //trabalha com chamada da opçao desejada
            if (op == 1)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("---> Selecionado " + op);
                chamadaImpressao(1);               
            }
            else if (op == 2)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("---> Selecionado " + op);
                chamadaImpressao(2);
            }
            else if (op == 3)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("---> Selecionado " + op);
                chamadaImpressao(3);
            }
            //caso op seja diferente de 1,2 e 3
            else
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("---> Selecionado " + op);
                Console.WriteLine("Opção'incorreta!");
                Console.WriteLine("Voltando para o menu!");
                controleMain();
            }
        }

        static void Main(string[] args)
        {
            //chamada controle do menu
            controleMain();
        }
    }
}



