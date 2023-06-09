using System;

namespace Principal
{
    public class ClasseMain
    {
        public static void Main(string[] args)
        {
            DefineOrdemDaMatriz(out int ordem, out string[,] matrizQuadrada);
            InsereElementosDaMatriz(ordem, matrizQuadrada);
            InformaMatrizCriada(matrizQuadrada);
            DefineDiagonais(matrizQuadrada, out string[] diagonalPrincipal, out string[] diagonalSecundaria);
            TrocaDiagonaisEntreSi(matrizQuadrada, diagonalPrincipal, diagonalSecundaria);
            InverteElementosDasDiagonais(matrizQuadrada, diagonalPrincipal, diagonalSecundaria);
        }


        //Não ficou claro para mim se o objetivo do exercício era trocar as diagonais entre si, fazendo a diagonal principal
        //ficar na posição da secundária e vice-versa, ou se era para inverter a ordem dos elementos dentro de cada diagonal.
        //Por causa disso, decidi programar as duas possibilidades. Abaixo, o método troca uma diagonal com a outra.
        private static void TrocaDiagonaisEntreSi(string[,] matrizQuadrada, string[] diagonalPrincipal, string[] diagonalSecundaria)
        {
            int ordemMatriz = matrizQuadrada.GetLength(0);
            string[,] matrizComDiagonaisTrocadas = (string[,])matrizQuadrada.Clone();
            for (int i = 0; i < ordemMatriz; i++)
            {
                matrizComDiagonaisTrocadas[i, i] = diagonalSecundaria[i];
                for (int j = 0; j < ordemMatriz; j++)
                {
                    if (i + j == ordemMatriz - 1)
                        matrizComDiagonaisTrocadas[i, j] = diagonalPrincipal[i];
                }
            }
            int count = 0;

            Console.WriteLine("\n\nA matriz com as diagonais trocadas entre si é: \n");

            foreach (string elemento in matrizComDiagonaisTrocadas)
            {
                if (count % ordemMatriz == 0 && count != 0)
                    Console.WriteLine("\n");

                count++;
                Console.Write(elemento + "  ");
            }
        }

        //Abaixo, temos a segunda possibilidade que eu comentei, de modo que as diagonais da matriz terão os elementos
        //com posição reversa em relação à posição original.
        private static void InverteElementosDasDiagonais(string[,] matrizQuadrada, string[] diagonalPrincipal, string[] diagonalSecundaria)
        {
            diagonalPrincipal = diagonalPrincipal.Reverse().ToArray();
            diagonalSecundaria = diagonalSecundaria.Reverse().ToArray();
            int ordemMatriz = matrizQuadrada.GetLength(0);
            for (int i = 0; i < ordemMatriz; i++)
            {
                for (int j = 0; j < ordemMatriz; j++)
                {
                    matrizQuadrada[i, i] = diagonalPrincipal[i];
                    if (i + j == ordemMatriz - 1)
                        matrizQuadrada[i, j] = diagonalSecundaria[i];
                }
            }
            int count = 0;

            Console.WriteLine("\n\nA matriz com os elementos revertidos dentro de cada diagonal é: \n");

            foreach (string elemento in matrizQuadrada)
            {
                if (count % ordemMatriz == 0 && count != 0)
                    Console.WriteLine("\n");

                count++;
                Console.Write(elemento + "  ");
            }
            Console.WriteLine("\n\n\nPrograma finalizado com sucesso!\n");
        }

        private static void DefineOrdemDaMatriz(out int ordem, out string[,] matrizQuadrada)
        {
            while (true)
            {
                Console.Write("Informe a ordem da matriz quadrada: ");
                try
                {
                    ordem = Convert.ToInt32(Console.ReadLine());
                    matrizQuadrada = new string[ordem, ordem];
                    break;
                }
                catch
                {
                    Console.WriteLine("A ordem precisa ser um número inteiro. Corrija o valor informado.\n");
                }
            }
        }

        private static void InsereElementosDaMatriz(int ordem, string[,] matrizQuadrada)
        {
            for (int i = 1; i <= ordem; i++)
            {
                Console.WriteLine($"Escreva os elementos da linha {i} separados por um espaço em branco: ");
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

        private static void InformaMatrizCriada(string[,] matrizQuadrada)
        {
            Console.WriteLine("\nA matriz que você informou é: \n");
            int ordemMatriz = matrizQuadrada.GetLength(0);
            int count = 0;
            foreach (string elemento in matrizQuadrada)
            {
                if (count % ordemMatriz == 0 && count != 0)
                    Console.WriteLine("\n");

                Console.Write(elemento + "  ");
                count++;
            }
        }

        private static void DefineDiagonais(string[,] matrizQuadrada, out string[] diagonalPrincipal, out string[] diagonalSecundaria)
        {
            int ordemMatriz = matrizQuadrada.GetLength(0);
            diagonalPrincipal = new string[ordemMatriz];
            for (int i = 0; i < diagonalPrincipal.Length; i++)
            {
                diagonalPrincipal[i] = matrizQuadrada[i, i];
            }
            diagonalSecundaria = new string[ordemMatriz];
            for (int j = 0; j < ordemMatriz; j++)
            {
                for (int k = 0; k < ordemMatriz; k++)
                {
                    if (j + k == ordemMatriz - 1)
                        diagonalSecundaria[j] = matrizQuadrada[j, k];
                }
            }
        }
    }
}