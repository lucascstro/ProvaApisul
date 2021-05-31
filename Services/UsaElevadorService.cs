
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProjeProvaAdimissionalApisul.Services
{
    public class UsaElevadorService : IElevadorService
    {
        //retorna andar menos utilizado
        public List<int> andarMenosUtilizado(List<Voto> votos)
        {
            int[] andar = new int[16];
            List<int> intList = new List<int>();
            foreach (var item in votos)
            {
                intList.Add(item.Andar);

            }
            //array de andares, qtd de votos no anda i   
            andar[0] = intList.Count(i => i == 0);
            andar[1] = intList.Count(i => i == 1);
            andar[2] = intList.Count(i => i == 2);
            andar[3] = intList.Count(i => i == 3);
            andar[4] = intList.Count(i => i == 4);
            andar[5] = intList.Count(i => i == 5);
            andar[6] = intList.Count(i => i == 6);
            andar[7] = intList.Count(i => i == 7);
            andar[8] = intList.Count(i => i == 8);
            andar[9] = intList.Count(i => i == 9);
            andar[10] = intList.Count(i => i == 10);
            andar[11] = intList.Count(i => i == 11);
            andar[12] = intList.Count(i => i == 12);
            andar[13] = intList.Count(i => i == 13);
            andar[14] = intList.Count(i => i == 14);
            andar[15] = intList.Count(i => i == 15);

            //pega menos andar
            int menor = andar.Min();

            //lista de retorno
            List<int> retornoMenor = new List<int>();

            //adiciona esse andar na lista de retorno
            for (int i = 0; i < andar.Length; i++)
            {
                if (andar[i] == menor)
                {
                    retornoMenor.Add(Convert.ToInt32(i));
                }
            }

            return retornoMenor;

        }
        //retorna elevador mais frequentado
        public List<char> elevadorMaisFrequentado(List<Voto> votos)
        {
            Voto[] votosData = new Voto[votos.Count];
            int elevadorA = 0, elevadorB = 0, elevadorC = 0, elevadorD = 0, elevadorE = 0, x = 0;
            char elevadorMaisFreq, elevadorMaisFreq2;

            foreach (var item in votos)
            {
                votosData[x] = new Voto { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }

            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {
                if (votosData[i].Elevador == 'A')
                {
                    elevadorA += 1;
                }
                if (votosData[i].Elevador == 'B')
                {
                    elevadorB += 1;
                }
                if (votosData[i].Elevador == 'C')
                {
                    elevadorC += 1;
                }
                if (votosData[i].Elevador == 'D')
                {
                    elevadorD += 1;
                }
                if (votosData[i].Elevador == 'E')
                {
                    elevadorE += 1;
                }
            }
            //pega elevador mais utilizado
            elevadorMaisFreq = comparaMaiorElevador(elevadorA, elevadorB, elevadorC, elevadorD, elevadorE);

            elevadorA = 0;
            elevadorB = 0;
            elevadorC = 0;
            elevadorD = 0;
            elevadorE = 0;

            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {
                if (votosData[i].Elevador == 'A' && votosData[i].Elevador != elevadorMaisFreq)
                {
                    elevadorA += 1;
                }
                if (votosData[i].Elevador == 'B' && votosData[i].Elevador != elevadorMaisFreq)
                {
                    elevadorB += 1;
                }
                if (votosData[i].Elevador == 'C' && votosData[i].Elevador != elevadorMaisFreq)
                {
                    elevadorC += 1;
                }
                if (votosData[i].Elevador == 'D' && votosData[i].Elevador != elevadorMaisFreq)
                {
                    elevadorD += 1;
                }
                if (votosData[i].Elevador == 'E' && votosData[i].Elevador != elevadorMaisFreq)
                {
                    elevadorE += 1;
                }
            }

            //pega segundo elevaodr mais utilizado
            elevadorMaisFreq2 = comparaMaiorElevador(elevadorA, elevadorB, elevadorC, elevadorD, elevadorE);

            List<char> retornoElevador = new List<char>() { elevadorMaisFreq, elevadorMaisFreq2 };

            return retornoElevador;
        }
        //retorna elevador menos frequentado
        public List<char> elevadorMenosFrequentado(List<Voto> votos)
        {
            Voto[] votosData = new Voto[votos.Count];
            int elevadorA = 999, elevadorB = 999, elevadorC = 999, elevadorD = 999, elevadorE = 999, x = 0;
            char elevadorMenosFreq, elevadorMenosFreq2;

            foreach (var item in votos)
            {
                votosData[x] = new Voto { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }

            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {
                if (votosData[i].Elevador == 'A')
                {
                    elevadorA -= 1;
                }
                if (votosData[i].Elevador == 'B')
                {
                    elevadorB -= 1;
                }
                if (votosData[i].Elevador == 'C')
                {
                    elevadorC -= 1;
                }
                if (votosData[i].Elevador == 'D')
                {
                    elevadorD -= 1;
                }
                if (votosData[i].Elevador == 'E')
                {
                    elevadorE -= 1;
                }
            }
            //pega retorno do primeiro menor valor
            elevadorMenosFreq = comparaMenorElevador(elevadorA, elevadorB, elevadorC, elevadorD, elevadorE, 1);
            //pega retorno do segundo menor valor
            elevadorMenosFreq2 = comparaMenorElevador(elevadorA, elevadorB, elevadorC, elevadorD, elevadorE, 2);
            //adiciona valores na lsita
            List<char> retornoElevador = new List<char>() { elevadorMenosFreq, elevadorMenosFreq2 };
            //retorna lista
            return retornoElevador;

        }
        //retorna periodo de maior fluxo e elevador mais utilizado neste periodo
        public List<char> periodoMaiorFluxoElevadorMaisFrequentado(List<Voto> votos)
        {
            Voto[] votosData = new Voto[votos.Count];

            int x = 0;
            foreach (var item in votos)
            {
                votosData[x] = new Voto() { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }

            int elevadorA = 0, elevadorB = 0, elevadorC = 0, elevadorD = 0, elevadorE = 0, periodoManha = 0, periodoVespertino = 0, periodoNoite = 0;
            char periodoMaisFreq, elevadorMaisFreq;

            //percorre todos os votos
            for (int i = 0; i < votos.Count; i++)
            {

                //Compara quantidade de vezes que o elevador mais frequentado foi utilizado em determinado periodo e soma um na sua variavel
                if (votosData[i].Periodo == 'M')
                {
                    periodoManha += 1;
                }
                if (votosData[i].Periodo == 'V')
                {
                    periodoVespertino += 1;
                }
                if (votosData[i].Periodo == 'N')
                {
                    periodoNoite += 1;
                }

            }

            //Compara cada periodos, pega o mais utilizado e atribui a periodoMaisFreq
            if (periodoManha > periodoVespertino && periodoManha > periodoNoite)
            {
                periodoMaisFreq = 'M';
            }
            else
            {
                if (periodoVespertino > periodoNoite)
                {
                    periodoMaisFreq = 'V';
                }
                else
                {
                    periodoMaisFreq = 'N';
                }
            }



            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {
                if (votosData[i].Periodo == periodoMaisFreq)
                {

                    if (votosData[i].Elevador == 'A')
                    {
                        elevadorA += 1;
                    }
                    if (votosData[i].Elevador == 'B')
                    {
                        elevadorB += 1;
                    }
                    if (votosData[i].Elevador == 'C')
                    {
                        elevadorC += 1;
                    }
                    if (votosData[i].Elevador == 'D')
                    {
                        elevadorD += 1;
                    }
                    if (votosData[i].Elevador == 'E')
                    {
                        elevadorE += 1;
                    }
                }

            }
            //dentro dos votos, pega somente os votos que sao do maior elevador

            //Compara quantidade de vezes que cada elevador foi utilizado e atriubui o maior a elevadorMaisFreq
            if (elevadorA > elevadorB)
            {//a maior q b
                if (elevadorA > elevadorC)
                {//a maior q c
                    if (elevadorA > elevadorD)
                    {// amaior q d
                        if (elevadorA > elevadorE)
                        {
                            //a maior q E
                            elevadorMaisFreq = 'A';
                        }
                        else
                        {
                            //E maior q a
                            elevadorMaisFreq = 'E';
                        }
                    }
                    else
                    {
                        //d maior q a
                        elevadorMaisFreq = 'D';
                    }
                }
                else
                {
                    //c maior q a
                    elevadorMaisFreq = 'C';
                }
            }
            else
            {//b maior que a
                if (elevadorB > elevadorC)
                { //B maior que a c
                    if (elevadorB > elevadorD)
                    {//B maior que a d
                        if (elevadorB > elevadorE)
                        {//B maior que a e
                            elevadorMaisFreq = 'B';
                        }
                        else
                        {
                            //e maior que a b
                            elevadorMaisFreq = 'E';
                        }
                    }
                    else
                    {
                        //d maior que a b
                        elevadorMaisFreq = 'D';
                    }
                }
                else
                {
                    if (elevadorC > elevadorD)
                    {
                        //c maior que a b  d 
                        if (elevadorC > elevadorE)
                        {//c maior que a b c d e
                            elevadorMaisFreq = 'C';
                        }
                        else
                        {
                            elevadorMaisFreq = 'E';
                        }

                    }
                    else
                    {
                        if (elevadorD > elevadorE)
                        {
                            //d maior que a b c e 
                            elevadorMaisFreq = 'D';
                        }
                        else
                        {
                            //e maior q todos
                            elevadorMaisFreq = 'E';
                        }
                    }
                }
            }



            List<char> retornoPeriodoElevador = new List<char>() { periodoMaisFreq, elevadorMaisFreq };

            return retornoPeriodoElevador;
        }
        //retornar periodo de menor fluxo e elevador menos utilizado neste periodo
        public List<char> periodoMenorFluxoElevadorMenosFrequentado(List<Voto> votos)
        {
            Voto[] votosData = new Voto[votos.Count];

            int x = 0;
            foreach (var item in votos)
            {
                votosData[x] = new Voto() { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }

            int elevadorA = 0, elevadorB = 0, elevadorC = 0, elevadorD = 0, elevadorE = 0, periodoManha = 0, periodoVespertino = 0, periodoNoite = 0;
            char periodoMenorFreq, elevadorMenorFreq;

            //percorre todos os votos
            for (int i = 0; i < votos.Count; i++)
            {

                //Compara quantidade de vezes que o elevador mais frequentado foi utilizado em determinado periodo e soma um na sua variavel
                if (votosData[i].Periodo == 'M')
                {
                    periodoManha += 1;
                }
                if (votosData[i].Periodo == 'V')
                {
                    periodoVespertino += 1;
                }
                if (votosData[i].Periodo == 'N')
                {
                    periodoNoite += 1;
                }

            }

            //Compara cada periodos, pega o mais utilizado e atribui a periodoMaisFreq
            if (periodoManha < periodoVespertino && periodoManha < periodoNoite)
            {
                periodoMenorFreq = 'M';
            }
            else
            {
                if (periodoVespertino < periodoNoite)
                {
                    periodoMenorFreq = 'V';
                }
                else
                {
                    periodoMenorFreq = 'N';
                }
            }

            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {
                if (votosData[i].Periodo == periodoMenorFreq)
                {

                    if (votosData[i].Elevador == 'A')
                    {
                        elevadorA -= 1;
                    }
                    if (votosData[i].Elevador == 'B')
                    {
                        elevadorB -= 1;
                    }
                    if (votosData[i].Elevador == 'C')
                    {
                        elevadorC -= 1;
                    }
                    if (votosData[i].Elevador == 'D')
                    {
                        elevadorD -= 1;
                    }
                    if (votosData[i].Elevador == 'E')
                    {
                        elevadorE -= 1;
                    }
                }

            }
            //dentro dos votos, pega somente os votos que sao do maior elevador

            //Compara quantidade de vezes que cada elevador foi utilizado e atriubui o maior a elevadorMaisFreq
            if (elevadorA < elevadorB)
            {//a maior q b
                elevadorMenorFreq = 'A';
                if (elevadorA < elevadorC)
                {//a maior q c
                    elevadorMenorFreq = 'A';
                    if (elevadorA < elevadorD)
                    {// amaior q d
                        elevadorMenorFreq = 'A';
                        if (elevadorA < elevadorE)
                        {
                            //a maior q E
                            elevadorMenorFreq = 'A';
                        }
                        else
                        {
                            //E maior q a
                            elevadorMenorFreq = 'E';
                        }
                    }
                    else
                    {
                        //d maior q a
                        elevadorMenorFreq = 'D';
                    }
                }
                else
                {
                    //c maior q a
                    elevadorMenorFreq = 'C';
                }
            }
            else
            {
                if (elevadorB < elevadorC)
                {
                    elevadorMenorFreq = 'B';
                    if (elevadorB < elevadorD)
                    {
                        elevadorMenorFreq = 'B';
                        if (elevadorB < elevadorE)
                        {
                            elevadorMenorFreq = 'B';
                        }
                        else
                        {
                            elevadorMenorFreq = 'E';
                        }
                    }
                    else
                    {
                        elevadorMenorFreq = 'D';
                    }
                }
                else
                {
                    elevadorMenorFreq = 'C';
                    if (elevadorC < elevadorD)
                    {
                        elevadorMenorFreq = 'C';
                        if (elevadorC < elevadorE)
                        {
                            elevadorMenorFreq = 'C';
                        }
                        else
                        {
                            elevadorMenorFreq = 'E';

                        }
                    }
                    else
                    {
                        if (elevadorD < elevadorE)
                        {
                            elevadorMenorFreq = 'D';
                        }
                        else
                        {
                            elevadorMenorFreq = 'E';
                        }
                    }
                }
            }


            List<char> retornoPeriodoElevador = new List<char>() { periodoMenorFreq, elevadorMenorFreq };

            return retornoPeriodoElevador;

        }
        //retorna periodo de maior utilizacao dos elevadores em conjunto
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores(List<Voto> votos)
        {
            //variaveis para cada periodo zerada
            int periodoManha = 0, periodoTarde = 0, periodoNoite = 0;
            //instancia a um array do tipo Voto
            Voto[] votosData = new Voto[votos.Count];

            //preenche array com dados vindos do paramento list
            int x = 0;
            foreach (var item in votos)
            {
                votosData[x] = new Voto() { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }
            //Atribui +1 para cada periodo especifico encontrado nos votos
            for (int i = 0; i < votos.Count; i++)
            {
                if (votosData[i].Periodo == 'M')
                {
                    periodoManha += 1;
                }
                if (votosData[i].Periodo == 'V')
                {
                    periodoTarde += 1;
                }
                if (votosData[i].Periodo == 'N')
                {
                    periodoNoite += 1;
                }
            }
            //instacia lista de retorno
            List<char> retMaiorConju = new List<char>();

            //verifica qual o periodo maior com mais utilizacao e adiciona na lista de retorno
            if (periodoManha > periodoTarde && periodoManha > periodoNoite)
            {
                retMaiorConju.Add('M');
            }
            else
            {
                if (periodoTarde > periodoNoite)
                {
                    retMaiorConju.Add('V');
                }
                else
                {
                    retMaiorConju.Add('N');
                }
            }
            //retorna lista com perido mais utilizado
            return retMaiorConju;
        }
        //retorna elevador mais utilizado e qual o periodo de maior fluxo deste elevador
        public List<char> elevadorMaisFrequentadoPeriodoMaiorFluxo(List<Voto> votos)
        {
            Voto[] votosData = new Voto[votos.Count];

            int x = 0;
            foreach (var item in votos)
            {
                votosData[x] = new Voto() { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }

            int elevadorA = 0, elevadorB = 0, elevadorC = 0, elevadorD = 0, elevadorE = 0, periodoManha = 0, periodoVespertino = 0, periodoNoite = 0;
            char periodoMaisFreq, elevadorMaisrFreq;

            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {

                if (votosData[i].Elevador == 'A')
                {
                    elevadorA += 1;
                }
                if (votosData[i].Elevador == 'B')
                {
                    elevadorB += 1;
                }
                if (votosData[i].Elevador == 'C')
                {
                    elevadorC += 1;
                }
                if (votosData[i].Elevador == 'D')
                {
                    elevadorD += 1;
                }
                if (votosData[i].Elevador == 'E')
                {
                    elevadorE += 1;
                }

            }
            //dentro dos votos, pega somente os votos que sao do maior elevador
            elevadorMaisrFreq = comparaMaiorElevador(elevadorA, elevadorB, elevadorC, elevadorD, elevadorE);

            //Compara quantidade de vezes que cada elevador foi utilizado e atriubui o maior a elevadorMaisFreq
            for (int i = 0; i < votos.Count; i++)
            {

                if (votosData[i].Periodo == 'M')
                {
                    periodoManha += 1;
                }
                if (votosData[i].Periodo == 'V')
                {
                    periodoVespertino += 1;
                }
                if (votosData[i].Elevador == 'N')
                {
                    periodoNoite += 1;
                }

            }
            periodoMaisFreq = comparaMaiorPeriodo(periodoManha, periodoVespertino, periodoNoite);

            List<char> retornoElevadorPeriodoMaior = new List<char>() { elevadorMaisrFreq, periodoMaisFreq };

            return retornoElevadorPeriodoMaior;

        }
        //retorna elevador menos utilizado e qual o periodo de menor fluxo deste elevador
        public List<char> elevadorMenosFrequentadoPeriodoMenorFluxo(List<Voto> votos)
        {

            Voto[] votosData = new Voto[votos.Count];

            int x = 0;
            foreach (var item in votos)
            {
                votosData[x] = new Voto() { Andar = item.Andar, Elevador = item.Elevador, Periodo = item.Periodo };
                x++;
            }

            int elevadorA = 999, elevadorB = 999, elevadorC = 999, elevadorD = 999, elevadorE = 999, periodoManha = 999, periodoVespertino = 999, periodoNoite = 999;
            char periodoMenosFreq, elevadorMenosFreq;

            //pecorre todo votos e verifica elevador mais utilizado
            for (int i = 0; i < votos.Count; i++)
            {

                if (votosData[i].Elevador == 'A')
                {
                    elevadorA -= 1;
                }
                if (votosData[i].Elevador == 'B')
                {
                    elevadorB -= 1;
                }
                if (votosData[i].Elevador == 'C')
                {
                    elevadorC -= 1;
                }
                if (votosData[i].Elevador == 'D')
                {
                    elevadorD -= 1;
                }
                if (votosData[i].Elevador == 'E')
                {
                    elevadorE -= 1;
                }

            }
            //dentro dos votos, pega somente os votos que sao do maior elevador
            elevadorMenosFreq = comparaMenorElevador(elevadorA, elevadorB, elevadorC, elevadorD, elevadorE, 2);

            //Compara quantidade de vezes que cada elevador foi utilizado e atriubui o maior a elevadorMaisFreq
            for (int i = 0; i < votos.Count; i++)
            {

                if (votosData[i].Periodo == 'M')
                {
                    periodoManha -= 1;
                }
                if (votosData[i].Periodo == 'V')
                {
                    periodoVespertino -= 1;
                }
                if (votosData[i].Elevador == 'N')
                {
                    periodoNoite -= 1;
                }

            }
            periodoMenosFreq = comparaMenorPeriodo(periodoManha, periodoVespertino, periodoNoite);

            List<char> retornoElevadorPeriodoMenor = new List<char>() { elevadorMenosFreq, periodoMenosFreq };

            return retornoElevadorPeriodoMenor;

        }
        //retorna a porcentagem de utilizacao do elevador A
        public float percentualDeUsoElevadorA(List<Voto> votos)
        {
            int sum = 0, i = 0;
            float percent, usoElevador;

            Voto[] votosData = new Voto[votos.Count];

            foreach (var items in votos)
            {
                votosData[i] = new Voto() { Andar = items.Andar, Periodo = items.Periodo, Elevador = items.Elevador };
                i++;
            }

            for (int x = 0; x < votosData.Length; x++)
            {
                if (votosData[x].Elevador == 'A')
                {
                    sum += 1;
                }
            }
            usoElevador = UsoElevador(votos);
            percent = (sum / usoElevador * 100);

            string cnv = "";
            cnv = percent.ToString("N2");
            float sumF = float.Parse(cnv);

            return sumF;
        }
        ///retorna a porcentagem de utilizacao do elevador B
        public float percentualDeUsoElevadorB(List<Voto> votos)
        {
            int sum = 0, i = 0;
            float percent, usoElevador;

            Voto[] votosData = new Voto[votos.Count];

            foreach (var items in votos)
            {
                votosData[i] = new Voto() { Andar = items.Andar, Periodo = items.Periodo, Elevador = items.Elevador };
                i++;
            }

            for (int x = 0; x < votosData.Length; x++)
            {
                if (votosData[x].Elevador == 'B')
                {
                    sum += 1;
                }
            }
            usoElevador = UsoElevador(votos);
            percent = (sum / usoElevador * 100);

            string cnv = "";
            cnv = percent.ToString("N2");
            float sumF = float.Parse(cnv);

            return sumF;
        }
        //retorna a porcentagem de utilizacao do elevador C
        public float percentualDeUsoElevadorC(List<Voto> votos)
        {
            int sum = 0, i = 0;
            float percent, usoElevador;

            Voto[] votosData = new Voto[votos.Count];

            foreach (var items in votos)
            {
                votosData[i] = new Voto() { Andar = items.Andar, Periodo = items.Periodo, Elevador = items.Elevador };
                i++;
            }

            for (int x = 0; x < votosData.Length; x++)
            {
                if (votosData[x].Elevador == 'C')
                {
                    sum += 1;
                }
            }
            usoElevador = UsoElevador(votos);
            percent = (sum / usoElevador * 100);

            string cnv = "";
            cnv = percent.ToString("N2");
            float sumF = float.Parse(cnv);

            return sumF;
        }
        //retorna a porcentagem de utilizacao do elevador D
        public float percentualDeUsoElevadorD(List<Voto> votos)
        {
            int sum = 0, i = 0;
            float percent, usoElevador;

            Voto[] votosData = new Voto[votos.Count];

            foreach (var items in votos)
            {
                votosData[i] = new Voto() { Andar = items.Andar, Periodo = items.Periodo, Elevador = items.Elevador };
                i++;
            }

            for (int x = 0; x < votosData.Length; x++)
            {
                if (votosData[x].Elevador == 'D')
                {
                    sum += 1;
                }
            }
            usoElevador = UsoElevador(votos);
            percent = (sum / usoElevador * 100);

            string cnv = "";
            cnv = percent.ToString("N2");
            float sumF = float.Parse(cnv);

            return sumF;
        }
        //retorna a porcentagem de utilizacao do elevador E
        public float percentualDeUsoElevadorE(List<Voto> votos)
        {
            int sum = 0, i = 0;
            float percent, usoElevador;

            Voto[] votosData = new Voto[votos.Count];

            foreach (var items in votos)
            {
                votosData[i] = new Voto() { Andar = items.Andar, Periodo = items.Periodo, Elevador = items.Elevador };
                i++;
            }

            for (int x = 0; x < votosData.Length; x++)
            {
                if (votosData[x].Elevador == 'E')
                {
                    sum += 1;
                }
            }
            usoElevador = UsoElevador(votos);
            percent = (sum / usoElevador * 100);

            string cnv = "";
            cnv = percent.ToString("N2");
            float sumF = float.Parse(cnv);

            return sumF;
        }
        //retorna o maior elevador
        public char comparaMaiorElevador(int elevadorA, int elevadorB, int elevadorC, int elevadorD, int elevadorE)
        {
            char elevadorMaisFreq;
            //Compara quantidade de vezes que cada elevador foi utilizado e atriubui o maior a elevadorMaisFreq
            if (elevadorA > elevadorB)
            {//a maior q b
                if (elevadorA > elevadorC)
                {//a maior q c
                    if (elevadorA > elevadorD)
                    {// amaior q d
                        if (elevadorA > elevadorE)
                        {
                            //a maior q E
                            elevadorMaisFreq = 'A';
                        }
                        else
                        {
                            //E maior q a
                            elevadorMaisFreq = 'E';
                        }
                    }
                    else
                    {
                        //d maior q a
                        elevadorMaisFreq = 'D';
                    }
                }
                else
                {
                    //c maior q a
                    elevadorMaisFreq = 'C';
                }
            }
            else
            {//b maior que a
                if (elevadorB > elevadorC)
                { //B maior que a c
                    if (elevadorB > elevadorD)
                    {//B maior que a d
                        if (elevadorB > elevadorE)
                        {//B maior que a e
                            elevadorMaisFreq = 'B';
                        }
                        else
                        {
                            //e maior que a b
                            elevadorMaisFreq = 'E';
                        }
                    }
                    else
                    {
                        //d maior que a b
                        elevadorMaisFreq = 'D';
                    }
                }
                else
                {
                    if (elevadorC > elevadorD)
                    {
                        //c maior que a b  d 
                        if (elevadorC > elevadorE)
                        {//c maior que a b c d e
                            elevadorMaisFreq = 'C';
                        }
                        else
                        {
                            elevadorMaisFreq = 'E';
                        }

                    }
                    else
                    {
                        if (elevadorD > elevadorE)
                        {
                            //d maior que a b c e 
                            elevadorMaisFreq = 'D';
                        }
                        else
                        {
                            //e maior q todos
                            elevadorMaisFreq = 'E';
                        }
                    }
                }
            }
            return elevadorMaisFreq;
        }
              //retornar o menor elevador
        public char comparaMenorElevador(int elevadorA, int elevadorB, int elevadorC, int elevadorD, int elevadorE, int op)
        {
            char retelevadorMaisFreq = 'X', retelevadorMaisFreq2 = 'X';
            int elevadorMaisFreq;

            int[] teste = new int[5] { elevadorA, elevadorB, elevadorC, elevadorD, elevadorE };

            elevadorMaisFreq = teste.Max();
            bool passou = true;
            for (int i = 0; i < teste.Length; i++)
            {
                if (teste[i] == elevadorMaisFreq)
                {
                    if (passou)
                    {
                        if (i == 0)
                        {
                            retelevadorMaisFreq = 'A';
                            passou = false;
                        }
                        if (i == 1)
                        {
                            retelevadorMaisFreq = 'B';
                            passou = false;
                        }
                        if (i == 2)
                        {
                            retelevadorMaisFreq = 'C';
                            passou = false;
                        }
                        if (i == 3)
                        {
                            retelevadorMaisFreq = 'D';
                            passou = false;
                        }
                        if (i == 4)
                        {
                            retelevadorMaisFreq = 'E';
                            passou = false;
                        }
                    }
                }
            }
            passou = true;
            for (int i = 0; i < teste.Length; i++)
            {
                if (teste[i] == elevadorMaisFreq)
                {
                    if (passou)
                    {
                        if (i == 0)
                        {
                            teste[i] += 99;
                            passou = false;
                        }
                        if (i == 1)
                        {
                            teste[i] += 99;
                            passou = false;
                        }
                        if (i == 2)
                        {
                            teste[i] += 99;
                            passou = false;
                        }
                        if (i == 3)
                        {
                            teste[i] += 99;
                            passou = false;
                        }
                        if (i == 4)
                        {
                            teste[i] += 99;
                            passou = false;
                        }
                    }
                }
            }
            for (int i = 0; i < teste.Length; i++)
            {
                if (teste[i] == elevadorMaisFreq)
                {
                    if (i == 0)
                    {
                        retelevadorMaisFreq2 = 'A';
                    }
                    if (i == 1)
                    {
                        retelevadorMaisFreq2 = 'B';
                    }
                    if (i == 2)
                    {
                        retelevadorMaisFreq2 = 'C';
                    }
                    if (i == 3)
                    {
                        retelevadorMaisFreq2 = 'D';
                    }
                    if (i == 4)
                    {
                        retelevadorMaisFreq2 = 'E';
                    }
                }
            }

            if (op == 1)
            {
                return retelevadorMaisFreq;
            }
            else
            {
                return retelevadorMaisFreq2;
            }
        }
        //retorna o maior periodo
        public char comparaMaiorPeriodo(int periodoManha, int periodoVespertino, int periodoNoite)
        {
            char periodoMaiorrFreq;
            //Compara cada periodos, pega o mais utilizado e atribui a periodoMaisFreq
            if (periodoManha > periodoVespertino && periodoManha > periodoNoite)
            {
                periodoMaiorrFreq = 'M';
            }
            else
            {
                if (periodoVespertino > periodoNoite)
                {
                    periodoMaiorrFreq = 'V';
                }
                else
                {
                    periodoMaiorrFreq = 'N';
                }
            }

            return periodoMaiorrFreq;
        }
        //retorna o menor periodo        
        public char comparaMenorPeriodo(int periodoManha, int periodoVespertino, int periodoNoite)
        {
            char periodoMenorFreq;
            //Compara cada periodos, pega o mais utilizado e atribui a periodoMaisFreq
            if (periodoManha > periodoVespertino && periodoManha > periodoNoite)
            {
                periodoMenorFreq = 'M';
            }
            else
            {
                if (periodoVespertino > periodoNoite)
                {
                    periodoMenorFreq = 'V';
                }
                else
                {
                    periodoMenorFreq = 'N';
                }
            }

            return periodoMenorFreq;
        }
        //porcentagem da utilizacao do elevador;
        public float UsoElevador(List<Voto> votos)
        {

            float sum = 0.0f;

            foreach (var items in votos)
            {
                sum += 1;
            }
            return sum;
        }
    }
}