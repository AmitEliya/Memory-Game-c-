using System;
using System.Collections.Generic;
using System.Text;


namespace Logic
{
    public class Board
    {
        private int m_Hight;
        private int m_Width;
        private Card[,] m_Board;
        private int m_TotalCardDiscoverd;

        public int Height
        {
            get
            {
                return m_Hight;
            }
            set
            {
                m_Hight = value;
            }
        }

        public int Wight
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }

        public int TotalCardDiscoverd
        {
            get 
            {
                return m_TotalCardDiscoverd;
            }
            set
            {
                m_TotalCardDiscoverd = value;
            }
        }

        public Card[,] TheBoard
        {
            get
            {
                return m_Board;
            }
            set
            {
                m_Board = value;
            }
        }

        public bool CheckIfSizeOk(int i_Hight, int i_Width)
        {
            bool result = true;

            if ((i_Hight * i_Width) % 2 == 1)
            {
                result = false;
            }

            return result;
        }
    
        public bool IsIndexOk(char i_Column, int i_Row, ref StringBuilder io_ErrorMessage)
        {
            int intColumn = i_Column - 'A';
            bool result = true;

            if (i_Row < 1 || i_Row > m_Hight || intColumn < 0 || intColumn >= m_Width )
            {
                io_ErrorMessage.Append("Not in the board limits!");
                result = false;
            }
            else if (!m_Board[i_Row - 1, intColumn].IsCovered)
            {
                io_ErrorMessage.Append("This card in already open!");
                result = false;
            }
            return result;
        }

        public Card GetCardByIndex(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        public void TurningCard(Card i_Card)
        {
            m_Board[i_Card.RowIndex, i_Card.ColumnIndex].IsCovered = !m_Board[i_Card.RowIndex, i_Card.ColumnIndex].IsCovered;
        }

        public void TurningCardByIndex(int i_Row, int i_Column)
        {
            m_Board[i_Row, i_Column].IsCovered = !m_Board[i_Row, i_Column].IsCovered;
        }

        public void InitBorad(int i_Higth, int i_Width, object[] i_ObjectsArray)
        {
            List<(int, int)> availableIndices = new List<(int, int)>();
            Random random = new Random();
            int firstIndex, secondIndex;
            int index = 0;

            m_Hight = i_Higth;
            m_Width = i_Width;
            m_Board = new Card[m_Hight, m_Width];
            for (int i = 0; i < m_Hight; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    availableIndices.Add((i, j));
                }
            }
            while (availableIndices.Count > 0)
            {
                firstIndex = random.Next(availableIndices.Count);
                (int, int) cell1 = availableIndices[firstIndex];

                availableIndices.RemoveAt(firstIndex);
                secondIndex = random.Next(availableIndices.Count);
                (int, int) cell2 = availableIndices[secondIndex];

                availableIndices.RemoveAt(secondIndex);
                m_Board[cell1.Item1, cell1.Item2] = new Card(i_ObjectsArray[index], cell1.Item1, cell1.Item2);
                m_Board[cell2.Item1, cell2.Item2] = new Card(i_ObjectsArray[index], cell2.Item1, cell2.Item2);
                index++;
            }

            m_TotalCardDiscoverd = 0;
        }
    }
}
