using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApplication
{
    class PolinomialCodification
    {
        public List<String> BlocksWords(char[] Letters)
        {
            List<String> Blocks = new List<String>();
            String Block = "";
            for (int i = 0; i < Letters.Length; i++)
            {
                int value = (int)Letters[i];
                Block += CompleteHex(Convert.ToString(value, 2));
                if (Block.Length == 128)
                {
                    Blocks.Add(Block);
                    Block = "";
                }
            }
            if (Letters.Length < 16 || Blocks.Count < ((int)((Letters.Length) / 16) + 1))
            {
                Blocks.Add(Block);
            }
            return Blocks;
        }

        public String CompleteHex(String hex)
        {
            while (hex.Length < 8)
            {
                hex = "0" + hex;
            }
            return hex;
        }
        public int[] AddXOR(int[] A, int[] B)
        {
            int[] C = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                C[i] = (A[i] + B[i]) % 2;
            }
            return C;
        }
        public int[] MoveLeft(int[] A)
        {
            int[] B = new int[A.Length];
            for (int i = 0; i < A.Length - 1; i++)
            {
                B[i] = A[i + 1];
            }
            return B;
        }
        public int[] Multiply(int[] A, int value)
        {
            int[] B = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                B[i] = (A[i] * value);
            }
            return B;
        }
        public int[] Take(int[] A, int p)
        {
            int[] B = new int[p];
            for (int i = 0; i < p; i++)
            {
                B[i] = A[i];
            }
            return B;
        }
        public int[] Take(int[] A, int a, int b)
        {
            int[] B = new int[b - a];
            for (int i = a; i < b; i++)
            {
                B[i - a] = A[i];
            }
            return B;
        }
        public int[] Divide_Mod(int[] G, int[] T)
        {
            int[] Aux = Take(T, G.Length);
            int[] Aux1 = new int[G.Length];
            int Next = G.Length;
            while (Next < T.Length)
            {
                Aux1 = Multiply(G, (G[0] * Aux[0]));
                Aux = MoveLeft(AddXOR(Aux, Aux1));
                Aux[Aux.Length - 1] = T[Next];
                Next++;
            }
            return Take(Aux, 1, Aux.Length);
        }
        public int[] StringToint(String Word)
        {
            int[] A = new int[Word.Length];
            for (int i = 0; i < Word.Length; i++)
            {
                A[i] = Convert.ToInt32(Word[i]);
            }
            return A;
        }
        public String ArrayToString(List<String> Lines)
        {
            String Aux = "";
            foreach (String line in Lines)
            {
                Aux += line;
            }
            return Aux;
        }
        public String ArrayToString(List<String> Lines, bool sw)
        {
            String Aux = "";
            foreach (String line in Lines)
            {
                Aux = Aux + line + "\n";
            }
            return Aux;
        }
        public int[] Join(int[] A, int[] B)
        {
            int[] C = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                C[i] = A[i];
            }
            for (int i = A.Length; i < C.Length; i++)
            {
                C[i] = B[i - A.Length];
            }
            return C;
        }
        public String intToString(int[] A)
        {
            String B = "";
            for (int i = 0; i < A.Length; i++)
            {
                B += A[i];
            }
            return B;
        }
        public List<String> CodeWordsGenerator(List<String> DateWords, int[] G)
        {
            List<String> CodeWords = new List<String>();
            int[] Aux = new int[G.Length - 1];
            foreach (String Word in DateWords)
            {
                int[] W = StringToint(Word);
                int[] W1 = Join(W, Aux);
                int[] Mod = Divide_Mod(G, W1);
                int[] CodeWord = Join(W, Mod);
                CodeWords.Add(intToString(CodeWord));
            }
            /*for (String W:CodeWords) {
                System.out.println(W);
            }*/
            return CodeWords;
        }

        public bool Detection(List<String> DateWords, int[] G)
        {
            List<String> Aux = DateWords;
            foreach (String Word in Aux)
            {
                int[] w = StringToint(Word);
                int[] Mod = Divide_Mod(G, w);
                foreach (int i in Mod)
                {
                    if (i != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
 }
