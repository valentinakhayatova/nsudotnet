using System.Linq;

namespace TicTacToe.Models
{
    public class TicTacToeModel
    {
        public const int Size = 3;
        public TicTacToeModel()
        {
            Cells = new User?[Size, Size];
        }

        public void DoStep(User user, int r, int c)
        {
            Cells[r, c] = user;

            var val = Cells[0, c];
            int i;
            for (i = 0; i < Size && val != null; ++i)
            {
                if (val != Cells[i, c])
                {
                    break;   
                }
            }
            if (i == Size){
            
                Winer = val;
                return;
            }

            val = Cells[r, 0];
          
            for (i = 0; i < Size && val != null; ++i)
            {
                if (val != Cells[r, i])
                {
                    break;
                }
            }
            if (i == Size)
            {

                Winer = val;
                return;
            }

            val = Cells[0, 0];
            for (i = 0; i < Size && val != null; ++i)
            {
                if (val != Cells[i, i])
                {
                    break;
                }
            }
            if (i == Size)
            {
                Winer = val;
                return;
            }


            val = Cells[Size - 1, 0];
            for (i = 0; i < Size && val != null; ++i)
            {
                if (val != Cells[Size - 1 - i, i])
                {
                    break;
                }
            }
            if (i == Size)
            {
                Winer = val;
                return;
            }




        }

        public User? Winer { get; set; }

        public bool IsComplited
        {
            get
            {
                if (Winer != null)
                {
                    return true;
                }

                return Cells.Cast<User?>().All(cell => cell != null);
            }
        }


        public User?[,] Cells { get; private set; }
    }
}