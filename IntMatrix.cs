using System;

namespace MatricesApp
{
    // Clase para matriz de enteros con utilidades de impresión y búsqueda de extremos.
    public class IntMatrix
    {
        private readonly int[,] _data;

        public int Filas { get; }
        public int Columnas { get; }

        public IntMatrix(int filas, int columnas)
        {
            if (filas <= 0 || columnas <= 0) throw new ArgumentException("Dimensiones inválidas.");
            Filas = filas;
            Columnas = columnas;
            _data = new int[filas, columnas];
        }

        public int this[int fila, int col]
        {
            get => _data[fila, col];
            set => _data[fila, col] = value;
        }

        public void ImprimirTabla(string titulo)
        {
            Console.WriteLine($"== {titulo} ==");

            Console.Write("        ");
            for (int j = 0; j < Columnas; j++)
                Console.Write($"Col {j + 1,8}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 8 + Columnas * 8));

            // Filas
            for (int i = 0; i < Filas; i++)
            {
                Console.Write($"Fila {i + 1,2} |");
                for (int j = 0; j < Columnas; j++)
                    Console.Write($"{_data[i, j],8}");
                Console.WriteLine();
            }
        }

        public (int valor, int fila, int columna) Maximo()
        {
            int maxVal = _data[0, 0], maxF = 0, maxC = 0;
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    if (_data[i, j] > maxVal)
                    {
                        maxVal = _data[i, j];
                        maxF = i; maxC = j;
                    }
                }
            }
            return (maxVal, maxF, maxC);
        }

        public (int valor, int fila, int columna) Minimo()
        {
            int minVal = _data[0, 0], minF = 0, minC = 0;
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    if (_data[i, j] < minVal)
                    {
                        minVal = _data[i, j];
                        minF = i; minC = j;
                    }
                }
            }
            return (minVal, minF, minC);
        }
    }
}
