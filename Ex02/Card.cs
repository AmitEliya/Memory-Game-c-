namespace Logic
{
    public class Card
    {
        private object m_Value;
        private bool m_IsCoverd;
        private int m_RowIndex;
        private int m_ColumnIndex;

        public Card(object i_Value, int i_Row, int i_Column)
        {
            m_Value = i_Value;
            m_IsCoverd = true;
            m_RowIndex = i_Row;
            m_ColumnIndex = i_Column;
        }

        public object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

        public bool IsCovered
        {
            get
            {
                return m_IsCoverd;
            }
            set
            {
                m_IsCoverd = value;
            }
        }

        public int RowIndex
        {
            get
            {
                return m_RowIndex;
            }
        }

        public int ColumnIndex
        {
            get
            {
                return m_ColumnIndex;
            }
        }
    }
}
