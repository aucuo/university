namespace lab2
{
    // ����� ��� ��������� ���������� �������
    class ShipException : Exception
    {
        public ShipException(string message) : base(message) { }
        public override string Message
        {
            get
            {
                return "��-����! " + base.Message;
            }
        }
    }

    // ����� ��� ��������� ���������� ����
    class CabinCategoryException : Exception
    {
        public CabinCategoryException(string message) : base(message) { }
        public override string Message
        {
            get
            {
                return "��-����! " + base.Message;
            }
        }
    }

}