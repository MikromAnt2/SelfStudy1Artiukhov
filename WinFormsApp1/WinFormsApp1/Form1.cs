namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel4.Paint += new PaintEventHandler(panel4_Paint);
            panel6.Paint += new PaintEventHandler(panel6_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<int> DFS(int[,] adjacencyMatrix, int startNode)
        {
            int n = adjacencyMatrix.GetLength(0);
            bool[] visited = new bool[n];
            List<int> traversal = new List<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(startNode);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                if (!visited[node])
                {
                    visited[node] = true;
                    traversal.Add(node);
                    for (int i = n - 1; i >= 0; i--)
                    {
                        if (adjacencyMatrix[node, i] > 0 && !visited[i])
                        {
                            stack.Push(i);
                        }
                    }
                }
            }
            return traversal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox4.Text, out int startNode) || startNode < 1 || startNode > 8)
            {
                MessageBox.Show("Введіть коректний номер вершини (від 1 до 8).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            startNode = int.Parse(textBox4.Text) - 1;
            int[,] adjacencyMatrix = new int[8, 8]
            {
                { 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 0, 1, 0, 1 },
                { 0, 1, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 1 },
                { 0, 0, 0, 1, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 0, 0 },
                { 1, 1, 0, 1, 0, 0, 0, 0 }
            };
            var result = DFS(adjacencyMatrix, startNode);
            textBox1.Text = string.Join(" -> ", result.Select(n => (n + 1).ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox5.Text, out int startNode) || startNode < 1 || startNode > 6)
            {
                MessageBox.Show("Введіть коректний номер вершини (від 1 до 6).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            startNode = int.Parse(textBox5.Text) - 1;
            int[,] adjacencyMatrix = new int[6, 6]
            {
                { 0, 1, 1, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 0 },
                { 1, 1, 0, 1, 0, 0 },
                { 0, 1, 1, 0, 1, 1 },
                { 0, 1, 0, 1, 0, 0 },
                { 1, 0, 0, 1, 0, 0 }
            };
            var result = DFS(adjacencyMatrix, startNode);
            textBox2.Text = string.Join(" -> ", result.Select(n => (n + 1).ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int startNode) || startNode < 1 || startNode > 6)
            {
                MessageBox.Show("Введіть коректний номер вершини (від 1 до 6).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            startNode = int.Parse(textBox6.Text) - 1;
            int[,] adjacencyMatrix = new int[6, 6]
            {
                { 0, 0, 0, 1, 1, 1 },
                { 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0 },
                { 1, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 1 },
                { 1, 1, 0, 0, 1, 0 }
            };
            var result = DFS(adjacencyMatrix, startNode);
            textBox3.Text = string.Join(" -> ", result.Select(n => (n + 1).ToString()));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] nodes = new Point[]
            {
                new Point(120, 50),
                new Point(170, 80),
                new Point(190, 140),
                new Point(170, 200),
                new Point(120, 220),
                new Point(70, 200),
                new Point(50, 140),
                new Point(70, 80) 
            };
            (int start, int end)[] edges = new (int, int)[]
            {
                (0, 1),
                (0, 7),
                (1, 2),
                (1, 7),
                (1, 5),
                (2, 6),
                (3, 4),
                (3, 7),
                (4, 5),
                (5, 6),
            };
            foreach (var edge in edges)
            {
                Point startPoint = nodes[edge.start];
                Point endPoint = nodes[edge.end];
                g.DrawLine(Pens.Black, startPoint, endPoint);
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                g.FillEllipse(Brushes.White, nodes[i].X - 15, nodes[i].Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, nodes[i].X - 15, nodes[i].Y - 15, 30, 30);
                g.DrawString((i + 1).ToString(), new Font("Arial", 10), Brushes.Black, nodes[i].X - 5, nodes[i].Y - 5);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] nodes = new Point[]
            {
                new Point(130, 50),
                new Point(50, 130),
                new Point(130, 130),
                new Point(130, 210),
                new Point(50, 210),
                new Point(200, 130),
            };
            (int start, int end)[] edges = new (int, int)[]
            {
                (0, 1),
                (0, 2),
                (0, 5),
                (1, 2),
                (1, 3),
                (1, 4),
                (2, 3),
                (3, 4),
                (3, 5)
            };
            foreach (var edge in edges)
            {
                Point startPoint = nodes[edge.start];
                Point endPoint = nodes[edge.end];
                g.DrawLine(Pens.Black, startPoint, endPoint);
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                g.FillEllipse(Brushes.White, nodes[i].X - 15, nodes[i].Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, nodes[i].X - 15, nodes[i].Y - 15, 30, 30);
                g.DrawString((i + 1).ToString(), new Font("Arial", 10), Brushes.Black, nodes[i].X - 5, nodes[i].Y - 5);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] nodes = new Point[]
            {
                new Point(50, 100),
                new Point(120, 80),
                new Point(190, 100),
                new Point(50, 180),
                new Point(120, 200),
                new Point(190, 180),
            };
            (int start, int end)[] edges = new (int, int)[]
            {
                (0, 3),
                (0, 4),
                (0, 5),
                (1, 3),
                (1, 5),
                (2, 4),
                (4, 5),
                (5, 4)
            };
            foreach (var edge in edges)
            {
                Point startPoint = nodes[edge.start];
                Point endPoint = nodes[edge.end];
                g.DrawLine(Pens.Black, startPoint, endPoint);
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                g.FillEllipse(Brushes.White, nodes[i].X - 15, nodes[i].Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, nodes[i].X - 15, nodes[i].Y - 15, 30, 30);
                g.DrawString((i + 1).ToString(), new Font("Arial", 10), Brushes.Black, nodes[i].X - 5, nodes[i].Y - 5);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
