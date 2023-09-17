
int[] m = new int[] { 1, 2, 3, 44, 5, 6 };
int cursor = 1;

// 44,5,1,2,3.

for (int idx = 0; idx < m.Length; idx++)
{
    int i = (idx + cursor) % m.Length;
    //if (i >= m.Length)
    //{
    //    i -= m.Length;
    //}
    WriteLine(m[i]);
}

Console.WriteLine("Цикл закончился");



// 1 : idx = 0
// 2 : idx < m.Length
// 3 : { ... }
// 4 : idx++
// 5 : idx < m.Length
// 6 : { ... }
// 7 : idx++
// 8 : ... до тех пор пока idx < m.Length