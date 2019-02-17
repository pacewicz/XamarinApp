using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using System.Collections;

namespace XamarinApplication
{
    public partial class MainPage : ContentPage
    {
        static String[] Graph3 = {"1 2" ,"2 3" ,"3 4" ,"4 5" ,"5 6" ,"6 7" ,"7 8" ,
                                    "8 9" ,"9 10" ,"10 11" ,"11 12" ,"12 13" ,"13 14" ,
                                    "14 15" ,"15 16" ,"16 17" ,"17 18" ,"18 19" ,"19 20" ,
                                    "20 21" ,"21 22" ,"22 23" ,"23 24" ,"24 25" ,"25 26" ,
                                    "26 27" ,"27 28" ,"28 29" ,"29 30" ,"30 31" ,"31 32" ,
                                    "32 33" ,"33 34" ,"34 35" ,"35 36" ,"36 37" ,"37 38" ,
                                    "38 39" ,"39 40" ,"40 41" ,"41 42" ,"42 43" ,"43 44" ,
                                    "44 45" ,"45 46" ,"46 47" ,"47 48" ,"48 49" ,"49 50" ,
                                    "50 1" ,"1 5" ,"1 10" ,"1 15" ,"1 20" ,"2 6" ,"2 11" ,
                                    "2 16" ,"2 21" ,"3 7" ,"3 12" ,"3 17" ,"3 22" ,"4 8" ,
                                    "4 13" ,"4 18" ,"4 23" ,"5 9" ,"5 14" ,"5 19" ,"5 24" ,
                                    "6 25" ,"6 30" ,"6 35" ,"6 40" ,"7 26" ,"7 31" ,"7 36" ,
                                    "7 41" ,"8 27" ,"8 32" ,"8 37" ,"8 42" ,"9 28" ,"9 33" ,
                                    "9 38" ,"9 43" ,"10 29" ,"10 34" ,"10 39" ,"10 44" ,"11 30" ,
                                    "11 35" ,"11 40" ,"11 45" ,"19 35" ,"19 40" ,"19 45" ,
                                    "19 50" ,"20 36" ,"20 41" ,"20 46" ,"21 37" ,
                                    "21 42" ,"21 47" ,"22 43" ,"22 44" ,"22 46" ,
                                    "24 35" ,"25 36" ,"27 37" ,"28 38" ,"29 39" ,
                                    "30 49" ,"15 37" ,"15 39" ,"15 42" ,"15 46" ,
                                    "16 43" ,"16 48" ,"16 49" ,"16 50" ,"13 27" ,
                                    "13 29" ,"13 32" ,"13 36" ,"18 48" ,"48 23" ,
                                    "48 27" ,"4 39" ,"4 37" ,"4 32" ,"9 37" ,"50 17" ,
                                    "50 20" ,"50 22" ,"1 38" ,"44 32" ,"38 21" ,
                                    "47 24" ,"47 25" ,"47 26" ,"33 45" ,"35 45" ,
                                    "40 25" ,"40 23" ,"40 18" ,"40 7" ,"45 16" ,
                                    "1 32" ,"12 27" ,"12 29" ,"12 31" ,"12 35" ,
                                    "12 40" ,"12 44" ,"37 48" ,"30 42" ,"30 48" ,
                                    "25 45" ,"30 45" ,"22 42" ,"17 37" ,"50 42" ,
                                    "50 32" ,"50 29" ,"50 27" ,"3 36" ,"3 32" ,
                                    "3 29" ,"11 32" ,"11 36" ,"18 32" ,"9 19" ,
                                    "14 26" ,"15 33" ,"15 35" ,"5 33" ,"5 35" ,
                                    "43 33" ,"46 33" ,"43 30" ,"30 46" ,"27 43" ,
                                    "27 46" ,"23 36" ,"23 38" ,"23 43" ,"23 46" ,
                                    "10 43" ,"10 38" ,"10 36" ,"10 33" ,"10 30" ,
                                    "19 30" ,"10 19" ,"6 26" ,"18 6" ,"18 39" ,
                                    "5 21" ,"5 25" ,"5 28" ,"5 31" ,"5 34" ,"5 41" ,
                                    "11 21" ,"11 25" ,"11 28" ,"11 31" ,"11 34" ,
                                    "11 50" ,"13 50" ,"15 50" ,"8 50" ,"1 43" ,
                                    "2 40" ,"2 35" ,"2 31" ,"2 28" ,"2 26" ,"3 44" ,
                                    "3 27" ,"3 23" ,"3 20" ,"3 18" ,"3 15" ,"38 25" ,
                                    "38 22" ,"38 13" ,"8 45" ,"8 46" ,"7 46" ,"7 47" ,
                                    "7 48" ,"1 17" ,"1 19" ,"1 29" ,"1 43" ,"41 9" ,
                                    "41 12" ,"41 14" ,"41 16" ,"41 21" ,"41 24" ,
                                    "41 30" ,"30 9" ,"30 12" ,"30 14" ,"30 16" ,"18 13" ,
                                    "18 37" ,"18 42" ,"18 45" ,"8 48" ,"8 28" ,"8 34" ,
                                    "8 36" ,"8 43" ,"6 15" ,"6 17" ,"6 19" ,"6 21" ,
                                    "6 29" ,"6 32" ,"6 34" ,"6 36" ,"6 43" ,"5 26" ,
                                    "5 30" ,"5 38" ,"5 40" ,"7 14" ,"7 24" ,"7 37" ,
                                    "9 16" ,"9 25" ,"9 31" ,"9 35" ,"9 42" ,"13 25" ,
                                    "13 31" ,"13 35" ,"13 39" ,"4 20" ,"4 22" ,"4 28" ,
                                    "4 6" ,"4 9" ,"6 9" ,"6 14" ,"18 21" ,"21 23" ,
                                    "18 23" ,"18 27" ,"23 30" ,"29 34" ,"34 36" ,"36 38" ,
                                    "38 41" ,"41 43" ,"43 46" ,"14 9" ,"14 20" ,"9 20" ,
                                    "20 23" ,"23 29" ,"20 29" ,"23 32" ,"32 45" ,"45 9" ,
                                    "21 17" ,"5 17" ,"15 24" ,"15 27" ,"18 12" ,"28 25" ,
                                    "22 28" ,"22 25" ,"46 42" ,"38 42" ,"35 38" ,"35 46" ,
                                    "49 41" ,"49 47" ,"48 34" ,"48 39" ,"34 39"};

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Execute();
            long memory = GC.GetTotalMemory(true);
            Result.Text = Result.Text + " RAM Usage : " + (Int32)(memory/1000000) + " MB\n"; 
            //int P = long.Parse(GC.MaxGeneration.ToString()) - GC.GetTotalMemory(false)/ long.Parse(GC.MaxGeneration.ToString());
            //Result = Result + " " + " %" + " max = " + GC.MaxGeneration + "Total  = " + GC.GetTotalMemory(false);
        }


        public long Fact(long n)
        {
            long FACT = 1;
            for (long i = 1; i < n; i++)
            {
                FACT = FACT * i;
            }
            return FACT;
        }

        public long Combinatory(int n, int k)
        {
            return Fact(n) / (Fact(n - k) * Fact(k));
        }

        public double Sin(double x, long n)
        {
            double Sin = 0;
            for (int i = 0; i < n; i++)
            {
                Sin += (Math.Pow(-1, i) / (Fact(2 * i + 1))) * Math.Pow(x, (2 * i + 1));
            }
            return Sin;
        }

        public double Cos(double x, long n)
        {
            double Sin = 0;
            for (int i = 0; i < n; i++)
            {
                Sin += (Math.Pow(-1, i) / (Fact(2 * i))) * Math.Pow(x, (2 * i));
            }
            return Sin;
        }

        public double Decimal()
        {
            Random rnd = new Random();
            double Number = rnd.Next(1, 180);
            for (int i = 0; i < 1000; i++)
            {
                int Exp = rnd.Next(20, 60);
                Number = Number + Math.Pow(2, -Exp);
            }
            return Number;
        }

        public void FloatingPoint(int iterations)
        {
	        var watch = System.Diagnostics.Stopwatch.StartNew();
			double[] a1 = new double[iterations];
	        double[] a2 = new double[iterations];

	        for (int i = 0; i < iterations; i++)
	        {
		        a1[i] = Decimal();
		        a2[i] = Decimal();
	        }
			watch.Stop();
			Result.Text = Result.Text + "Random*"+iterations*2+" "+ watch.ElapsedMilliseconds +"ms \n";
			watch = System.Diagnostics.Stopwatch.StartNew();

            Result.Text = Result.Text + $"Start : Floating Point*{iterations} \n";
            for (int i = 0; i < iterations; i++)
            {
                Cos(a1[i], 1000);
                Sin(a2[i], 1000);

            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Result.Text = Result.Text + "Execution Time : " + elapsedMs + " ms";
        }

        public void Execute()
        {

            Result.Text = Result.Text + "Start : Process \n";
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //Processes

            const int iterations = 40;
            FloatingPoint(iterations);
            Sorts();
            executer();
            ExecuterCOD();

            //Processes
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Result.Text = Result.Text + "Total Execution Time : " + elapsedMs + " ms \n";


        }


        //
        //Sorts
        //

        public int[] InsertSort(int[] V)
        {
            int aux;

            for (int i = 1; i < V.Length; i++)
            {
                aux = V[i];
                for (int j = i - 1; j >= 0 && V[j] < aux; j--)
                {
                    int aux2 = V[j];
                    V[j + 1] = aux2;
                    V[j] = aux;
                }
            }
            return V;
        }
        public int[] SelectSort(int[] V)
        {
            for (int i = 0; i < V.Length - 1; i++)
            {
                int index = i;
                for (int j = i; j < V.Length; j++)
                {
                    if (V[index] < V[j])
                    {
                        index = j;
                    }
                }
                int aux = V[i];
                V[i] = V[index];
                V[index] = aux;

            }
            return V;
        }

        public int[] QuickSort(int[] V, int left, int right)
        {
            if (left >= right)
            {
                return V;
            }
            int i = left;
            int d = right;

            if (left != right)
            {
                int Pivot = left;
                int Aux;
                while (left != right)
                {

                    while (V[right] <= V[left] && left < right)
                    {
                        right--;
                    }
                    while (V[left] > V[right] && left < right)
                    {
                        left--;
                    }
                    if (right != left)
                    {
                        Aux = V[right];
                        V[right] = V[left];
                        V[left] = Aux;
                    }
                    if (right == left)
                    {
                        QuickSort(V, i, left - 1);
                        QuickSort(V, left + 1, d);
                    }
                }
            }
            else
            {
                return V;
            }
            return V;
        }

        public int[] BubbleSort(int[] V)
        {
            int t;
            for (int a = 1; a < V.Length; a++)
            {
                for (int b = V.Length - 1; b >= a; b--)
                {
                    if (V[b - 1] > V[b])
                    {
                        t = V[b - 1];
                        V[b - 1] = V[b];
                        V[b] = t;
                    }
                }
            }
            return V;
        }

        public int[] Generator()
        {
	        int[] V =
	        {
		        60542, 48715, 68836, 61560, 38143, 60018, 49420, 50131, 67509, 63722, 81141, 28243, 74859, 62409, 10587,
		        76205, 92352, 88940, 2538, 8910, 93053, 53494, 11596, 69625, 26902, 1928, 87144, 77861, 97150, 28711,
		        64516, 62731, 61255, 11383, 52593, 97564, 35028, 47037, 58981, 19772, 94412, 5201, 92936, 8187, 5240,
		        18642, 35547, 73359, 24252, 50734, 29267, 96526, 44541, 55439, 97773, 48335, 56625, 8451, 59722, 31794,
		        59065, 30520, 32695, 2698, 72540, 83243, 6721, 90385, 70262, 38824, 15530, 57865, 58323, 43218, 63515,
		        84101, 66056, 33266, 68206, 65236, 19880, 81388, 69820, 28127, 59366, 85452, 97320, 74765, 74224, 7823,
		        11782, 15452, 30562, 62720, 33411, 57706, 77394, 75618, 86009, 77509, 38327, 16771, 37922, 81315, 87640,
		        49957, 75486, 1293, 35025, 61659, 11411, 2516, 63408, 40599, 57034, 80085, 14044, 40340, 37287, 14018,
		        91553, 24409, 80764, 18447, 47016, 80186, 20859, 31675, 57349, 53146, 2867, 1262, 45394, 74362, 48838,
		        21102, 72633, 60371, 61884, 63023, 85089, 85820, 20638, 87053, 3434, 52192, 2404, 5449, 94816, 62901,
		        56652, 63529, 50722, 39240, 59478, 2450, 10642, 2972, 77707, 34267, 22487, 52506, 73425, 34870, 89268,
		        18233, 77874, 44520, 89863, 47559, 34012, 67433, 37373, 45443, 12081, 20061, 77228, 68010, 79893, 34674,
		        19306, 66725, 25412, 51725, 1053, 86833, 97417, 43024, 59039, 15779, 70253, 16682, 97058, 23503, 99791,
		        77507, 80184, 17044, 71506, 24276, 319, 39922, 12323, 31044, 31435, 15746, 46121, 24255, 88444, 5640,
		        68770, 81111, 26661, 25544, 4515, 81077, 91673, 20044, 9246, 59096, 86940, 42035, 16239, 63397, 53044,
		        55964, 26228, 91087, 75423, 58671, 66960, 82932, 92435, 56241, 93671, 70417, 51200, 299, 21275, 32553,
		        91968, 94964, 90287, 12822, 14223, 82732, 3891, 93440, 24267, 4704, 71041, 32996, 68614, 55883, 94051,
		        20837, 96041, 62290, 34508, 1240, 70679, 18863, 82425, 82664, 19462, 74655, 7390, 45265, 96745, 75329,
		        60943, 41311, 19546, 86065, 3449, 13140, 53801, 33404, 56070, 86164, 35551, 96576, 4761, 21273, 9694,
		        75073, 40957, 77227, 7107, 26805, 3923, 36926, 98903, 66550, 61715, 90364, 68943, 11631, 28183, 76966,
		        2187, 37974, 9073, 66356, 14210, 65808, 18355, 98262, 36978, 21784, 98928, 42527, 16286, 24425, 61475,
		        64058, 15548, 85510, 21047, 88933, 30551, 10736, 18223, 45367, 96961, 68110, 27304, 80124, 18712, 49041,
		        58985, 28601, 96243, 17027, 5932, 24122, 19692, 53197, 44901, 45696, 7989, 8058, 69265, 24048, 77434,
		        71024, 99179, 70937, 89061, 43507, 74370, 64279, 17692, 25633, 37235, 39191, 59198, 29809, 6832, 20615,
		        51902, 63416, 81715, 42981, 10624, 87676, 90208, 37661, 61234, 86116, 59073, 63761, 27181, 56874, 11839,
		        67621, 55942, 63647, 32543, 11659, 35477, 17594, 24805, 68475, 22932, 70294, 13882, 7808, 77785, 45473,
		        60089, 2928, 29931, 93735, 79449, 70666, 32513, 44063, 67051, 64644, 95594, 86732, 21920, 78458, 22113,
		        92087, 97670, 39813, 42392, 48205, 16624, 91274, 99711, 143, 78407, 13058, 49362, 28229, 83709, 80072,
		        62131, 68215, 69959, 43893, 38819, 31956, 13961, 25955, 4937, 74075, 7040, 39153, 39843, 35723, 377,
		        61354, 64402, 74779, 43622, 16464, 79895, 83833, 74223, 12809, 15633, 66453, 85407, 50491, 45230, 27004,
		        74602, 44819, 40258, 6303, 52805, 26686, 98140, 41038, 90420, 53333, 74457, 25, 15934, 55968, 74029,
		        3000, 47081, 71569, 37433, 42728, 72745, 97368, 72279, 18136, 53988, 47938, 86114, 98914, 78408, 59679,
		        59337, 62930, 18987, 13137, 53485, 25631, 12263, 34241, 21272, 94125, 71226, 20438, 77150, 13581, 29077,
		        51334, 30661, 4702, 85216, 40483, 32949, 79540, 41191, 60554, 46004, 77965, 57374, 68401, 68780, 55438,
		        80484, 41372, 37859, 89227, 71969, 51207, 12579, 87525, 23573, 5796, 68179, 38082, 67400, 5575, 76725,
		        79758, 78049, 29337, 50046, 7171, 44396, 75216, 27441, 40489, 20157, 43577, 54644, 50485, 80629, 1268,
		        8354, 12451, 3838, 83864, 84809, 63126, 32091, 47043, 70845, 89943, 69218, 83050, 30677, 90723, 90203,
		        25997, 50373, 36809, 85189, 87903, 17720, 57170, 4736, 92217, 4850, 12686, 60117, 62942, 11829, 78111,
		        17751, 49532, 47688, 45889, 91348, 64007, 63959, 58064, 74186, 53991, 42958, 42349, 84533, 98453, 6978,
		        54656, 85165, 65539, 7837, 61846, 27211, 93650, 74098, 68615, 99921, 82258, 46344, 30430, 84890, 79548,
		        71409, 32661, 94162, 27280, 10919, 78826, 70946, 4177, 59621, 45929, 67542, 58714, 35917, 42478, 71990,
		        32521, 22916, 61546, 11975, 28717, 80285, 37286, 21897, 53115, 18855, 19704, 12687, 7099, 63318, 13849,
		        74230, 72106, 45660, 9760, 55180, 55283, 61946, 87621, 43283, 69311, 82053, 22220, 34651, 35449, 44735,
		        94710, 20747, 21145, 34671, 37741, 14721, 95747, 18768, 75037, 1374, 21765, 57429, 20788, 40195, 7021,
		        11666, 83198, 92087, 75621, 62732, 11883, 80351, 83855, 16148, 58902, 79063, 16848, 42863, 21795, 74610,
		        23103, 49247, 20803, 86948, 35219, 78045, 386, 38066, 16789, 79752, 46250, 83075, 33187, 66044, 87944,
		        55141, 70109, 35003, 83880, 84466, 31013, 62159, 40654, 63675, 71449, 44800, 1925, 62459, 86566, 48033,
		        72832, 20918, 80756, 70808, 18492, 91988, 11764, 97724, 76387, 28963, 97494, 18778, 73573, 46314, 47033,
		        97268, 84110, 25699, 88658, 339, 85483, 30817, 90284, 29662, 79296, 3932, 85676, 32729, 32316, 32959,
		        51363, 87925, 25567, 89091, 77091, 36507, 15742, 75126, 46242, 27828, 42496, 93758, 20708, 61640, 24220,
		        8077, 15538, 91371, 67433, 40523, 78846, 53105, 97868, 68157, 31297, 77819, 85950, 79774, 68062, 22370,
		        84329, 70185, 95233, 35415, 46056, 42973, 48679, 4813, 53829, 62486, 41227, 52397, 3927, 34623, 65747,
		        91595, 57630, 82293, 89359, 39372, 13578, 84847, 12916, 75759, 55015, 62500, 35923, 53501, 73971, 24004,
		        13269, 6247, 16605, 91450, 60080, 31417, 67402, 47627, 132, 95583, 91346, 88904, 27269, 10948, 75153,
		        33343, 68584, 15758, 89771, 68500, 19928, 48646, 34176, 26339, 81383, 51513, 22153, 54496, 71526, 562,
		        11018, 72944, 18366, 23331, 32144, 84287, 18195, 91301, 98089, 42504, 69967, 79990, 29197, 47181, 24290,
		        90181, 15188, 35069, 65440, 36276, 981, 61, 12071, 57151, 77128, 56710, 78865, 41052, 72285, 55562,
		        45367, 42973, 98764, 37267, 43469, 84798, 2992, 45404, 16650, 95537, 14616, 10768, 28865, 82584, 34274,
		        79079, 84715, 51333, 63239, 58883, 81888, 8812, 63498, 26605, 68460, 54882, 21477, 30557, 38843, 70821,
		        71790, 15127, 52705, 32816, 76226, 36820, 42382, 10027, 1151, 65715, 41147, 2716, 87514, 65606, 65690,
		        30702, 23790, 93784, 75529, 64213, 14771, 16160, 22927, 15169, 14314, 71939, 92315, 53944, 50891, 70959,
		        65150, 15265, 51144, 38275, 93191, 5930, 90938, 47359, 7741, 4560, 31005, 12319, 54849, 35758, 99672,
		        23333, 85417, 22368, 15013, 39174, 35706, 54727, 15303, 65264, 83117, 2658, 44385, 7076, 72287, 61165,
		        31351, 69138, 23593, 4821, 81608, 84064, 95191, 11946, 4883, 25622, 76710, 27850, 80716, 69142, 58268,
		        4854, 1125, 1281, 99595, 50969, 48264, 84659, 80494, 67072, 86651, 55111, 65710, 50322, 33205, 295,
		        27269, 2454, 49948, 46172, 36478, 29524, 26022, 90497, 8337, 45706, 79352, 46190, 68633, 14039, 67156,
		        61941, 22583, 98695, 51315, 99358, 39694, 34239, 86484, 69613, 84311
	        };
            return V;
        }

        public void Sorts()
        {
            int[] v = Generator();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Result.Text = Result.Text + "\n Start : Sorts \n";

            BubbleSort(v);
            InsertSort(v);
            SelectSort(v);
            QuickSort(v, 0, v.Length - 1);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Result.Text = Result.Text + "Execution Time : " + elapsedMs + " ms\n";
        }

        //Grafos-...
        public void Creator(Grafo g)
        {

            foreach (String Graph11 in Graph3)
            {
                String[] aux = Graph11.Split(' ');
                g.CrearGrafo(Convert.ToInt32(aux[0]), Convert.ToInt32(aux[1]));
            }

        }

        public void executer()
        {
            Result.Text = Result.Text + "Start graph algoritms \n";
            Grafo g = new Grafo(50, 326);
            Creator(g);
            var watch = System.Diagnostics.Stopwatch.StartNew();


            //
            g.Distancias();
            g.componentes();
            g.esArbol();
            g.Euleriano(50);
            g.Factorizable_1();
            g.Factorizable_2();
            g.R_Regular(50);
            g.Puentes();
            g.Hamiltoniano(50);
            g.Clique();
            g.Coloreado();
            //
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Result.Text = Result.Text + "Execution Time : " + elapsedMs + " ms\n";
        }

        public void ExecuterCOD()
        {
            String Chars = "Arittakeno yume o kakiatsume sagashi mono sagashini yuku no sa ONE PIECE! "
                 + "rashinban nante jyutai no moto netsu ni ukasare kaji o toru no sa HOKORI ka butteta "
                 + "takara no chizu mo tashikameta no nara densetsu jyanai! kojin teki na arashi wa dareka no "
                 + "BAIORIZUMU nokkatte omoi sugose ba ii arittakeno yume o kakiatsume sagashi mono sagashini yuku no sa "
                 + "POKETO no COIN , soreto YOU WANNA BE MY FRIEND? WE ARE, WE ARE ON THE CRUISE! WE ARE! "
                 + "zembu mani ukete shinji chattemo kata o osarete iippo LIDU sa kondo aetanara hanasu tsumorisa sore kara no koto to kore kara no koto"
                 + "tsumari itsumo PINCHI wa dareka ni " + "APPEAL dekiru ii CHANSU " + "ji ishiki kajyoo ni! " +
                 "shimittareta yoru o buttobase! " + "takara bako ni KYOUMI wa nai kedo POKETO ni roman, soreto " +
                 "YOU WANNA BE MY FRIEND? WE ARE, WE ARE ON THE CRUISE! WE ARE! " + "arittakeno yume o kakiatsume " +
                 "sagashi mono sagashini yuku no sa " + "POKETO no COIN , soreto " + "YOU WANNA BE MY FRIEND? " + "WE ARE, WE ARE ON THE CRUISE! "
                 + "WE ARE! " + "WE ARE! WE ARE!";

            Result.Text = Result.Text + "Start Codification \n";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            PolinomialCodification P = new PolinomialCodification();
            P.CodeWordsGenerator(P.BlocksWords(Chars.ToCharArray()), new int[] { 0, 1, 1, 0, 0, 0, 1 });

            HammingCodification H = new HammingCodification();
            List<String> ASCII = H.ToASCII(Chars);
            H.ArrayToString(ASCII, true);
            H.Codewords(ASCII);


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
           Result.Text = Result.Text + " Execution Time : " + elapsedMs + " ms\n";
            
        }



    }

}
