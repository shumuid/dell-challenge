namespace DellChallenge.C
{
    class MyObject
    {
        public int Do(params int[] list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }

            return sum;
        }
    }
}
