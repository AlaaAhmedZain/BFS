using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace traverse_grid
{
    public class traverse
    {
        public int R = 5;
        public int C = 7;
        public int[,] m;
        public int sr = 0;
        public int sc = 0;
        public Queue<int> rq = new Queue<int>();
        public Queue<int> cq = new Queue<int>();
        int move_count = 0;
        int nodes_left_in_layer = 1;
        int nodes_in_next_layer = 0;

        bool reached_end = false;
        bool[,] visited;
        int[] dr = new int[] { -1, 1, 0, 0 };
        int[] dc = new int[] { 0, 0, 1, -1 };
        public traverse()
        {
            m = new int[R, C];
            visited = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    m[i, j] = 1;
                }
            }

            m[0, 3] = 0;
            m[1, 1] = 0;
            m[1, 5] = 0;
            m[2, 1] = 0;
            m[3, 2] = 0;
            m[3, 3] = 0;
            m[4, 0] = 0;
            m[4, 2] = 0;
            m[4, 5] = 0;
            m[4, 3] = 9;

        }
        public int solve()
        {

            int r, c;
            rq.Enqueue(sc);
            cq.Enqueue(sc);
            visited[sr, sc] = true;
            while (rq.Count > 0 || cq.Count > 0)
            {
                r = rq.Dequeue();
                c = cq.Dequeue();
                if (m[r, c] == 9)
                {
                    reached_end = true;
                    break;
                }
                else
                {
                    explore_neighbours(r, c);
                    nodes_left_in_layer--;
                    if(nodes_left_in_layer==0)
                    {
                        nodes_left_in_layer = nodes_in_next_layer;
                        nodes_in_next_layer = 0;
                        move_count++;
                    }

                }
            }
            if (reached_end)
            {
                return move_count;
            }
            return -1;
        }



        private void explore_neighbours(int r, int c)
        {
            for (int i = 0; i < 4; i++)
            {
                int rr = r + dr[i];
                int cc = c + dc[i];
                if (rr < 0 || cc < 0) continue;
                if (rr >= R || cc >= C) continue;
                if (visited[rr, cc]) continue;
                if (m[rr, cc] == 0) continue;

                rq.Enqueue(rr);
                cq.Enqueue(cc);
                visited[rr, cc] = true;
                nodes_in_next_layer++;

            }
        }
    }
}
