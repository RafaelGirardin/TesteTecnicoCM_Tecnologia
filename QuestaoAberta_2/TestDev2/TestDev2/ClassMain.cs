using System;

namespace Principal
{
    public class ClassMain
    {
        public static void Main(string[] args)
        {
            int ordemMatrizPrincipal = 0;
            string[][,] vetorDeMatrizes = new string[2][,];

            for (int i = 0; i < 2; i++)
            {
                string nomeMatriz = string.Empty;
                if (i == 0)
                    nomeMatriz = "A";
                else
                    nomeMatriz = "B (submatriz)";

                string[,] matrizQuadrada;
                int ordem;

                if (i == 0)
                {
                    DefineOrdemDaMatriz(out ordem, out matrizQuadrada, nomeMatriz);
                    ordemMatrizPrincipal = ordem;
                }
                else
                    DefineOrdemDaMatriz(out ordem, out matrizQuadrada, nomeMatriz, ordemMatrizPrincipal);

                InsereElementosDaMatriz(ordem, ref matrizQuadrada, nomeMatriz);
                vetorDeMatrizes[i] = matrizQuadrada;
                InformaMatrizCriada(matrizQuadrada, nomeMatriz);
            }

            CalculaNumeroDeVezes(vetorDeMatrizes);
        }

        private static void CalculaNumeroDeVezes(string[][,] vetorDeMatrizes)
        {
            string[,] matrizPrincipal = vetorDeMatrizes[0];
            string[,] submatriz = vetorDeMatrizes[1];
            string primeiroElementoSubmatriz = submatriz[0, 0];
            List<int[]> primeirosElementosIguais = new List<int[]>();
            int ordemMatriz = matrizPrincipal.GetLength(0);

            for (int i = 0; i < ordemMatriz; i++)
            {
                for (int j = 0; j < ordemMatriz; j++)
                {
                    if (matrizPrincipal[i, j].Equals(primeiroElementoSubmatriz))
                    {
                        int[] posicao = new int[2];
                        posicao[0] = i;
                        posicao[1] = j;
                        primeirosElementosIguais.Add(posicao);
                    }
                }
            }

            int numeroSubmatrizes = 0;

            foreach (int[] elementoIgual in primeirosElementosIguais)
            {
                int posicaoX = elementoIgual[0];
                int posicaoY = elementoIgual[1];
                int count = 0;

                for (int i = 0; i < submatriz.GetLength(0); i++)
                {
                    if (i > 0 && i < matrizPrincipal.GetLength(0) - 1)
                    {
                        posicaoX++;
                        posicaoY = elementoIgual[1];
                    }

                    for (int j = 0; j < submatriz.GetLength(0); j++)
                    {
                        if (j > 0 && j < matrizPrincipal.GetLength(0) - 1)
                            posicaoY++;

                        if (posicaoX == matrizPrincipal.GetLength(0) || posicaoY == matrizPrincipal.GetLength(0))
                            break;

                        if (matrizPrincipal[posicaoX, posicaoY].Equals(submatriz[i, j]))
                            count++;

                        if (count == submatriz.Length)
                            numeroSubmatrizes++;
                    }
                }
            }

            Console.WriteLine($"A submatriz B cabe {numeroSubmatrizes} vez(es) na matriz A.");
        }

        private static void DefineOrdemDaMatriz(out int ordem, out string[,] matrizQuadrada, string nomeMatriz, int ordemMatrizPrincipal = 0)
        {
            while (true)
            {
                Console.Write($"Informe a ordem da matriz quadrada {nomeMatriz}: ");

                try
                {
                    ordem = Convert.ToInt32(Console.ReadLine());

                    if (nomeMatriz.Equals("B (submatriz)") && ordem >= ordemMatrizPrincipal)
                    {
                        Console.WriteLine("A submatriz deve ter ordem menor do que a matriz A. Tente mais uma vez.");
                        continue;
                    }

                    matrizQuadrada = new string[ordem, ordem];
                    break;
                }
                catch
                {
                    Console.WriteLine("A ordem precisa ser um número inteiro positivo. Corrija o valor informado.\n");
                }
            }
        }

        private static void InsereElementosDaMatriz(int ordem, ref string[,] matrizQuadrada, string nomeMatriz)
        {
            for (int i = 1; i <= ordem; i++)
            {
                Console.WriteLine($"Escreva os elementos da linha {i} da matriz {nomeMatriz} separados por um espaço em branco: ");
                string[] linhaDaMatriz = new string[ordem];
                linhaDaMatriz = Console.ReadLine().Split(" ");

                if (linhaDaMatriz.Length != ordem)
                {
                    Console.WriteLine("\nO número de elementos da linha precisa corresponder à ordem da matriz. Tente novamente.");
                    i--;
                    continue;
                }

                for (int j = 0; j < ordem; j++)
                {
                    matrizQuadrada[i - 1, j] = linhaDaMatriz[j];
                }
            }
        }

        private static void InformaMatrizCriada(string[,] matrizQuadrada, string nomeMatriz)
        {
            Console.WriteLine($"\nA matriz {nomeMatriz} que você informou é: \n");
            int ordemMatriz = matrizQuadrada.GetLength(0);
            int count = 0;

            foreach (string elemento in matrizQuadrada)
            {
                if (count % ordemMatriz == 0 && count != 0)
                    Console.WriteLine("\n");

                Console.Write(elemento + "  ");
                count++;
            }

            Console.WriteLine("\n");
        }

    }
}
