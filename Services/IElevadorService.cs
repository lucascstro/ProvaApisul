
using ProjeProvaAdimissionalApisul;
using System.Collections.Generic;

namespace ProvaAdmissionalCSharpApisul
{
  public interface IElevadorService
    {
        // <summary> Deve retornar uma List contendo o(s) andar(es) menos utilizado(s). </summary> 
        List<int> andarMenosUtilizado(List<Voto> votos);

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s). </summary> 
        List<char> elevadorMaisFrequentado(List<Voto> votos);      

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s). </summary> 
        List<char> elevadorMenosFrequentado(List<Voto> votos);
        /// <summary> Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
        List<char> periodoMaiorFluxoElevadorMaisFrequentado(List<Voto> votos);

        /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        List<char> periodoMenorFluxoElevadorMenosFrequentado(List<Voto> votos);

        /// <summary> Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
        List<char> elevadorMaisFrequentadoPeriodoMaiorFluxo(List<Voto> votos);

        /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        List<char> elevadorMenosFrequentadoPeriodoMenorFluxo(List<Voto> votos);

        /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores. </summary> 
        List<char> periodoMaiorUtilizacaoConjuntoElevadores(List<Voto> votos);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorA(List<Voto> votos);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorB(List<Voto> votos);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorC(List<Voto> votos);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorD(List<Voto> votos);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorE(List<Voto> votos);
  }
}