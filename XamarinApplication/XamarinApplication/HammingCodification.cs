using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApplication
{
    class HammingCodification
    {
        int Errors;

        public HammingCodification()
        {
            this.Errors = 0;
        }



        public List<String> ToASCII(String Text)
        {
            List<String> Codes = new List<String>();
            for (int x = 0; x < Text.Length; x++)
            {
                //System.out.println(Text.charAt(x) + " = " + Text.codePointAt(x));
                int L = (int)(Text[x]);
                Codes.Add(Convert.ToString(L, 2));
            }
            return Codes;
        }

        public String Codewords(List<String> ASCII)
        {
            String Codewords = "";
            foreach (String PalDatos in ASCII)
            {
                String pal = PalDatos;
                bool[] Palabra = new bool[8];
                bool[] Codigo = new bool[12];
                if (pal.Length < 8)
                {
                    while (pal.Length < 7)
                    {
                        pal = "0" + pal;
                    }
                }
                for (int i = 0; i < pal.Length; i++)
                {
                    if (pal[i].Equals("1"))
                    {
                        Palabra[i + 1] = true;
                    }
                    else
                    {
                        Palabra[i + 1] = false;
                    }
                }
                int j = 7;
                for (int i = 1; i <= 11; i++)
                {
                    if (i != 1 && i != 2 && i != 4 && i != 8)
                    {
                        Codigo[i] = Palabra[j];
                        j = j - 1;
                    }
                }
                Codigo[1] = Codigo[3] ^ Codigo[5] ^ Codigo[7] ^ Codigo[9] ^ Codigo[11];
                Codigo[2] = Codigo[3] ^ Codigo[6] ^ Codigo[7] ^ Codigo[10] ^ Codigo[11];
                Codigo[4] = Codigo[5] ^ Codigo[6] ^ Codigo[7];
                Codigo[8] = Codigo[9] ^ Codigo[10] ^ Codigo[11];
                String Code = "";
                for (int i = 11; i >= 1; i--)
                {
                    if (Codigo[i])
                    {
                        Code = Code + "1";
                    }
                    else
                    {
                        Code = Code + "0";
                    }
                }
                Codewords = Codewords + Code + "\n";
            }
            return Codewords;
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

        public String Correccion(List<String> Codes)
        {
            String Codewords = "";
            foreach (String Code in Codes)
            {
                bool[] Palabra = new bool[12];
                for (int i = Code.Length - 1; i >= 0; i--)
                {
                    if (Code[i] == '1')
                    {
                        Palabra[11 - (i)] = true;
                    }
                    else
                    {
                        Palabra[11 - (i)] = false;
                    }
                }
                String Codid = "";
                for (int i = 1; i <= 11; i++)
                {
                    if (Palabra[i])
                    {
                        Codid = Codid + "1";
                    }
                    else
                    {
                        Codid = Codid + "0";
                    }
                }
                bool C1, C2, C4, C8;
                String c1, c2, c4, c8;
                C1 = Palabra[1] ^ Palabra[3] ^ Palabra[5] ^ Palabra[7] ^ Palabra[9] ^ Palabra[11];
                C2 = Palabra[2] ^ Palabra[3] ^ Palabra[6] ^ Palabra[7] ^ Palabra[10] ^ Palabra[11];
                C4 = Palabra[4] ^ Palabra[5] ^ Palabra[6] ^ Palabra[7];
                C8 = Palabra[8] ^ Palabra[9] ^ Palabra[10] ^ Palabra[11];
                if (C8)
                {
                    c8 = "1";
                }
                else
                {
                    c8 = "0";
                }
                if (C4)
                {
                    c4 = "1";
                }
                else
                {
                    c4 = "0";
                }
                if (C2)
                {
                    c2 = "1";
                }
                else
                {
                    c2 = "0";
                }
                if (C1)
                {
                    c1 = "1";
                }
                else
                {
                    c1 = "0";
                }
                int malo = Convert.ToInt32(c8 + c4 + c2 + c1, 2);
                //System.out.println(malo + " " + Code);
                if (malo != 0)
                {
                    Palabra[malo] = !Palabra[malo];
                    String C = "";
                    for (int i = 11; i >= 1; i--)
                    {
                        if (Palabra[i])
                        {
                            C = C + "1";
                        }
                        else
                        {
                            C = C + "0";
                        }
                    }
                    Codewords = Codewords + C + "\n";
                    Errors = Errors + 1;
                }
                else
                {
                    Codewords = Codewords + Code + "\n";
                }
            }
            return Codewords;
        }
    }
}
