using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApplication
{
    public class Grafo
    {
            bool[,] Adj;
            int Vertices, Aristas;
            bool[] visitado;
            List<int> VerticesCorte1;

            int Pares = 0, Impares = 0;
            int Mayor1 = 0;
            int[] Conjunto;
            String[] Enlaces;
            bool EsConexo = false, EsRegular = false, EsBipartido = false, EsArbol = false;

            public Grafo(int v, int a)
            {
                this.Vertices = v;
                this.Aristas = a;
                Enlaces = new String[a + 1];
                Adj = new bool[v + 1, v + 1];
                Conjunto = new int[Vertices + 1];
            }
            int h = 1;

            public void CrearGrafo(int a, int b)
            {
                Enlaces[h] = a + "-" + b;
                Adj[b, a] = true;
                Adj[a, b] = true;
                Enlaces[h] = a + "-" + b;
                h++;
            }

            public String Factorizable_1()
            {
                if (EsConexo)
                {
                    if (EsBipartido && EsRegular && Mayor1 > 1)
                    {
                        return "Es 1-Factorizable";
                    }
                    else if (EsRegular && Mayor1 == Vertices - 1 && Vertices % 2 == 0)
                    {
                        return "Es 1-Factorizable";
                    }
                }
                return "No es 1-Factorizable";
            }

            public String Factorizable_2()
            {
                if (EsConexo)
                {
                    if (EsRegular && Mayor1 % 2 == 0)
                    {
                        return "Es 2-Factorizable";
                    }
                }
                return "No es 2-Factorizable";
            }

            public bool Adyacencia(List<int> Vertices, int Clique)
            {
                int Nodos = 0;
                for (int i = 0; i < Vertices.Count; i++)
                {
                    int Grados = 0;
                    for (int j = 0; j < Vertices.Count; j++)
                    {
                        if (i != j)
                        {
                            if (Adj[Vertices.ElementAt(i), Vertices.ElementAt(j)])
                            {
                                Grados++;
                            }
                        }
                    }
                    if (Grados >= Clique - 1)
                    {
                        Nodos++;
                    }
                }
                return Nodos == Clique;

            }

            public bool Completo(List<int> Nodos, int Clique)
            {
                for (int i = 0; i < Nodos.Count; i++)
                {
                    List<int> Noditos = new List<int>();
                    Noditos.Add(Nodos.ElementAt(i));
                    for (int j = 0; j < Nodos.Count; j++)
                    {
                        if (i != j)
                        {
                            if (Adj[Nodos.ElementAt(i), Nodos.ElementAt(j)])
                            {
                                Noditos.Add(Nodos.ElementAt(j));
                            }
                        }
                    }
                    if (Noditos.Count >= Clique && Adyacencia(Noditos, Clique))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int Clique()
            {
                int Clique = Mayor(Vertices) + 1;

                if (EsArbol)
                {
                    return 2;
                }
                if (EsRegular && Grado(1, Vertices) == Vertices - 1)
                {
                    return Clique;
                }
                else
                {
                    Clique--;
                    int Grado1 = Clique - 1;
                    while (Grado1 >= 2)
                    {
                        List<int> Pivotes = new List<int>();
                        for (int i = 1; i <= Vertices; i++)
                        {
                            if (Grado(i, Vertices) >= Grado1)
                            {
                                Pivotes.Add(i);
                            }
                        }
                        if (Completo(Pivotes, Clique))
                        {
                            return Clique;
                        }
                        Grado1 = Grado1 - 1;
                        Clique = Clique - 1;
                    }
                }
                return Clique;
            }

            public String Euleriano(int Vertices)
            {
                if (EsConexo)
                {
                    if (Menor(Vertices) == 1)
                    {
                        return "No es Euleriano";
                    }
                    if (EsArbol)
                    {
                        return "No es Euleriano";
                    }
                    for (int i = 1; i <= Vertices; i++)
                    {
                        if (Grado(i, Vertices) % 2 != 0)
                        {
                            return "No es Euleriano";
                        }
                    }
                    return "Es Euleriano";
                }
                else
                {
                    return "No es Euleriano";
                }
            }

            public String Hamiltoniano(int Vertices)
            {
                if (EsConexo)
                {
                    String Si = "Es Hamiltoniano";
                    String No = "No " + Si;
                    if (Impares / 2 == Vertices)
                    {
                        return Si;
                    }
                    if (Pares == Impares)
                    {
                        return Si;
                    }
                    if (Menor(Vertices) == 1)
                    {
                        return No;
                    }
                    if (EsArbol)
                    {
                        return No;
                    }
                    if (EsRegular)
                    {
                        return Si;
                    }

                    for (int i = 1; i <= Vertices; i++)
                    {
                        if (Grado(i, Vertices) < Vertices / 2)
                        {
                            return No;
                        }
                    }
                    return Si;
                }
                else
                {
                    return "No es Hamiltoniano";
                }
            }

            public String R_Regular(int Vertices)
            {
                if (Mayor(Vertices) == Menor(Vertices))
                {
                    EsRegular = true;
                    return "Es " + Grado(1, Vertices) + "-Regular";
                }
                else
                {
                    return "No es Regular";
                }
            }

            public int Grado(int nodo, int v)
            {
                int cont = 0;
                for (int i = 1; i <= v; i++)
                {
                    if (Adj[i, nodo] == true)
                    {
                        cont++;
                    }
                }

                return cont;
            }

            public int Mayor(int v)
            {
                int mayor = -1;
                for (int i = 1; i <= v; i++)
                {

                    if (Grado(i, v) > mayor)
                    {
                        mayor = Grado(i, v);
                    }
                    if (Grado(i, v) % 2 == 0)
                    {
                        Pares += 1;
                    }
                    else
                    {
                        Impares += 1;
                    }
                }
                Mayor1 = mayor;
                return mayor;
            }

            public int Menor(int v)
            {
                int menor = 8000;
                for (int i = 1; i <= v; i++)
                {

                    if (Grado(i, v) < menor)
                    {
                        menor = Grado(i, v);
                    }
                }
                return menor;

            }

            public void DFS(int v)
            {
                visitado[v] = true;
                for (int i = 1; i <= Vertices; ++i)
                {
                    if (Adj[v, i] && !visitado[i])
                    {
                        DFS(i);
                    }
                }
            }

            public void DFSBipartido(int v, int C)
            {

                visitado[v] = true;
                Conjunto[v] = C;
                for (int i = 1; i <= Vertices; ++i)
                {
                    if (Adj[v, i] == true && visitado[i] == false)
                    {
                        if (C == 1)
                        {
                            DFSBipartido(i, 2);
                        }
                        else
                        {
                            DFSBipartido(i, 1);
                        }
                    }
                }
            }
            int Ind = 0;

            public void DFSIndependiente(int v)
            {

                visitado[v] = true;
                Ind++;
                for (int i = 1; i <= Vertices; ++i)
                {
                    if (Adj[v, i] == true)
                    {
                        visitado[i] = true;
                    }
                }
                int j = 1, k = 1, menor = Aristas + 1, indice = 0;
                while (k <= Vertices)
                {
                    while (j <= Vertices)
                    {
                        if (Adj[k, j] == true && visitado[j] == false)
                        {
                            int grado = Grado(j, Vertices);
                            if (grado < menor)
                            {
                                menor = grado;
                                indice = j;
                            }
                        }
                        j++;
                    }
                    if (visitado[k] == false)
                    {
                        int grado = Grado(k, Vertices);
                        if (grado < menor)
                        {
                            menor = grado;
                            indice = k;
                        }
                    }
                    k++;
                }
                if (indice != 0)
                {
                    DFSIndependiente(indice);
                }
            }
            bool[] Avisitada;
            String[] Saturados;

            public String EmparejamientoPerfecto()
            {
                bool Empa = false;
                String Respuesta = "";
                if (Vertices % 2 == 0 && EsBipartido == false)
                {
                    Respuesta = "Si tiene Emparejamiento Perf";
                }
                else //Saturados=new String[Vertices+1];
                {
                    if (EsBipartido == true && EsRegular == true)
                    {
                        Respuesta = "Si tiene Emparejamiento Perf";
                    }
                    else
                    {
                        int i = 1;
                        while (i <= Vertices && Empa == false)
                        {
                            Sat = 0;
                            Saturados = new String[Vertices + 1];
                            Avisitada = new bool[Aristas + 1];
                            for (int j = 1; j <= Aristas; j++)
                            {
                                Avisitada[j] = false;
                            }
                            RecorrerAristas(i);
                            if (Sat == Vertices)
                            {
                                Empa = true;
                            }
                            else
                            {
                                i++;
                            }
                        }

                        //int i=1;
                        /*while(Empa==true && i<=Vertices){
                    int k=1;
                    bool Esta=false;
                    while(Esta==false && k<=Sat){
                        if (Convert.ToInt32(Saturados[k]) == i ) {
                            Esta=true;
                        }
                        k++;
                    }
                    if (Esta==false) {
                        Empa=false;
                    }else{
                    i++;
                    }
                }*/
                        if (Empa)
                        {
                            Respuesta = "Si tiene Emparejamiento Perf";
                        }
                        else
                        {
                            Respuesta = "No tiene Emparejamiento Perf";
                        }
                    }
                }
                return Respuesta;
            }
            int Sat = 0;

            public void RecorrerAristas(int A)
            {
                Avisitada[A] = true;
                String[] Nodos = Enlaces[A].Split('-');
                String nA = Nodos[0], nB = Nodos[1];
                bool Swesta = false;
                int k = 1;
                while (k <= Sat && Swesta == false)
                {
                    if (nA.Equals(Saturados[k]))
                    {
                        Swesta = true;
                    }
                    k++;
                }
                if (Swesta == false)
                {

                    Swesta = false;
                    k = 1;
                    while (k <= Sat && Swesta == false)
                    {
                        if (nB.Equals(Saturados[k]))
                        {
                            Swesta = true;
                        }
                        k++;
                    }
                    if (Swesta == false)
                    {
                        Sat++;
                        Saturados[Sat] = nA;
                        Sat++;
                        Saturados[Sat] = nB;

                    }
                }
                for (int i = 1; i <= Aristas; i++)
                {
                    if (i != A)
                    {
                        Nodos = Enlaces[i].Split('-');
                        if (!Nodos[0].Equals(nA) && !Nodos[1].Equals(nB) && Avisitada[i] == false)
                        {
                            RecorrerAristas(i);

                        }
                    }
                }
            }


            public int Puentes()
            {
                int Puentes = 0;
                for (int i = 1; i <= Aristas; i++)
                {
                    String[] Nodos = Enlaces[i].Split('-');
                    String nA = Nodos[0], nB = Nodos[1];
                    Adj[Convert.ToInt32(nA), Convert.ToInt32(nB)] = false;
                    Adj[Convert.ToInt32(nB), Convert.ToInt32(nA)] = false;
                    String Puente = esconexo();
                    if (!Puente.Equals("Es Conexo"))
                    {
                        Puentes++;
                    }
                    ReiniciarAdj();
                }
                ReiniciarAdj();
                return Puentes;

            }

            public int VerticesCorte()
            {
                VerticesCorte1 = new List<int>();
                int VerticesCortes = 0, NumVertices = Vertices;
                String[] Enlacescorte = new String[Aristas * 2];
                //int f;
                for (int k = 1; k <= Vertices; k++)
                {
                    //f=0;
                    bool[,] AdjCorte = new bool[Vertices + 1, Vertices + 1];
                    int Posv = 0;
                    for (int i = 1; i <= Vertices; i++)
                    {
                        if (i != k)
                        {
                            Posv++;
                            int Posa = 0;
                            for (int j = 1; j <= Vertices; j++)
                            {
                                if (j != k)
                                {
                                    Posa++;
                                    /*if (Adj[i,j]==true) {
                                              f++;
                                              Enlacescorte[f]= i + "-" + j;
                                            }*/
                                    AdjCorte[Posv, Posa] = Adj[i, j];
                                }
                            }
                        }
                    }
                    /*for (int i = 1; i <= f; i++) {
                       System.out.println(Enlacescorte[i]);
                   }*/
                    Adj = AdjCorte;
                    Vertices = Vertices - 1;
                    String Corte = esconexo();
                    if (!Corte.Equals("Es Conexo"))
                    {
                        VerticesCortes++;
                        VerticesCorte1.Add(k);

                    }
                    ReiniciarAdj();
                    Vertices = NumVertices;
                }
                ReiniciarAdj();
                Vertices = NumVertices;
                return VerticesCortes;
            }

            public void ReiniciarAdj()
            {
                for (int i = 1; i <= Vertices; i++)
                {
                    for (int j = 1; j <= Vertices; j++)
                    {
                        Adj[i, j] = false;
                    }
                }
                for (int i = 1; i <= Aristas; i++)
                {
                    String[] Nodos = Enlaces[i].Split('-');
                    String nA = Nodos[0], nB = Nodos[1];
                    Adj[Convert.ToInt32(nA), Convert.ToInt32(nB)] = true;
                    Adj[Convert.ToInt32(nB), Convert.ToInt32(nA)] = true;
                }
            }

            public String esconexo()
            {
                visitado = new bool[Vertices + 1];
                DFS(1);
                for (int i = 1; i <= Vertices; i++)
                {
                    if (!visitado[i])
                    {
                        return "No es Conexo k(g)= " + componentes();
                    }
                }
                EsConexo = true;
                return "Es Conexo";
            }

            public int componentes()
            {
                int comp = 0;
                visitado = new bool[Vertices + 1];
                for (int i = 1; i <= Vertices; i++)
                {
                    if (!visitado[i])
                    {
                        DFS(i);
                        comp++;
                    }
                }
                return comp;
            }

            public String Bipartido()
            {
                String Bipartido = "No es Bipartido";
                if (EsArbol)
                {
                    Bipartido = "Es Bipartido";
                    EsBipartido = true;
                }
                else if (EsConexo)
                {
                    int l = 1;
                    bool swConjuntos = false;
                    while (swConjuntos == false && l <= Vertices)
                    {
                        for (int i = 1; i <= Vertices; i++)
                        {
                            visitado[i] = false;
                        }
                        for (int i = 10; i <= Vertices; i++)
                        {
                            Conjunto[i] = 0;
                        }
                        DFSBipartido(l, 1);
                        int s = 1;
                        swConjuntos = true;
                        while (s <= Vertices && swConjuntos == true)
                        {
                            int k = 1;
                            while (k <= Vertices && swConjuntos == true)
                            {
                                if (Adj[s, k])
                                {
                                    if (Conjunto[s] == Conjunto[k])
                                    {
                                        swConjuntos = false;
                                    }
                                }
                                k++;
                            }
                            s++;
                        }
                        if (swConjuntos)
                        {
                            Bipartido = "Es Bipartido";
                            EsBipartido = true;

                        }
                        else
                        {
                            l++;
                        }
                    }
                }

                return Bipartido;
            }

            bool swBuscaCiclo = true;
            int NumCiclo = 0;
            int CicloN = 0;
            int[] NumeroCiclo = new int[1000000];




            public String esArbol()
            {
                if (EsConexo && Aristas == Vertices - 1)
                {
                    return "Es un Arbol";
                }
                return "No es Arbol";
            }

            public int Coloreado()
            {
                int color = 1;
                int[] Coloreado = new int[Vertices + 1];
                if (EsRegular && Mayor1 == (Vertices - 1))
                {
                    color = Vertices;
                }
                else if (EsBipartido)
                {
                    color = 2;
                }
                else
                {

                    List<int> NodosColor = Gradientes();
                    for (int i = 1; i <= Vertices; i++)
                    {
                        Coloreado[i] = 0;
                    }
                    for (int i = 0; i < Vertices; i++)
                    {
                        List<int> colorAdj = new List<int>();
                        for (int j = 1; j <= Vertices; j++)
                        {
                            if (Adj[NodosColor.ElementAt(i), j] == true)
                            {
                                if (Coloreado[j] > 0)
                                {
                                    colorAdj.Add(Coloreado[j]);
                                }
                            }
                        }
                        if (colorAdj.Count == 0)
                        {
                            Coloreado[NodosColor.ElementAt(i)] = 1;
                        }
                        else
                        {
                            int colorG = 1;
                            bool Noesta = false;
                            while (Noesta == false)
                            {
                                if (!colorAdj.Contains(colorG))
                                {
                                    Noesta = true;
                                    Coloreado[NodosColor.ElementAt(i)] = colorG;
                                }
                                else
                                {
                                    colorG++;
                                    if (colorG > color)
                                    {
                                        color = colorG;
                                    }
                                }
                            }
                        }
                    }

                }

                return color;
            }

            public List<int> Gradientes()
            {
                List<int> VerticesG = new List<int>();
                int mayor = -1, Indice = 0;
                for (int j = 1; j <= Vertices; j++)
                {
                    int Num = Grado(j, Vertices);
                    if (Num > mayor)
                    {
                        mayor = Num;
                        Indice = j;
                    }
                }
                VerticesG.Add(Indice);
                for (int i = 1; i <= Vertices; i++)
                {
                    mayor = -1;
                    for (int j = 1; j <= Vertices; j++)
                    {
                        if (!VerticesG.Contains(j))
                        {
                            int Num = Grado(j, Vertices);
                            if (Num > mayor)
                            {
                                mayor = Num;
                                Indice = j;
                            }
                        }
                    }
                    if (mayor != -1)
                    {
                        VerticesG.Add(Indice);
                    }

                }

                return VerticesG;
            }

            int[,] d;

            public void BFS(int ini)
            {
                LinkedList<pair> cola = new LinkedList<pair>();
                cola.AddLast(new pair(ini, 0));
                visitado = new bool[Vertices + 1];
                visitado[ini] = true;
                while (cola.Count != 0)
                {
                    pair v = cola.First();
                    cola.RemoveFirst();
                    //System.out.println("Estoy en el vertice " + v.a + " con distancia " + v.b);
                    d[v.a, ini] = v.b;
                    d[ini, v.a] = v.b;
                    for (int i = 1; i <= Vertices; ++i)
                    {
                        if (Adj[i, v.a] && !visitado[i])
                        {
                            cola.AddLast(new pair(i, v.b + 1));
                            visitado[i] = true;
                        }
                    }
                }
            }

            public String adyacencia()
            {
                String dat = "";
                int[,] Adyacencia = new int[Vertices + 1, Vertices + 1];
                for (int i = 1; i <= Vertices; i++)
                {
                    for (int j = 1; j <= Vertices; j++)
                    {
                        if (Adj[i, j])
                        {
                            Adyacencia[i, j] = 1;
                        }
                    }
                }
                for (int x = 1; x < Adyacencia.Length; x++)
                {
                    dat += "";
                    for (int y = 1; y < Adyacencia.Length; y++)
                    {
                        dat += Adyacencia[x, y];
                        if (y != Adyacencia.GetLength(x) - 1)
                        {
                            dat += " ";
                        }
                    }
                    dat += "\n";
                }
                return dat;
            }
            public void Distancias()
            {
                d = new int[Vertices + 1, Vertices + 1];
                for (int i = 1; i <= Vertices; i++)
                {
                    BFS(i);
                }
            }

        }

        class pair
        {

            public int a, b;

            public pair(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
        }
}
