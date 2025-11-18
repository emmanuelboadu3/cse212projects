using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create an array of doubles of size 'length'.
        // 2. For each index i from 0 to length-1, compute the (i+1)-th multiple: number * (i + 1).
        // 3. Store that value at result[i].
        // 4. Return the filled array.
        //
        // Note: The assignment states length > 0, but we include a defensive check to return an empty array
        // if a non-positive length is supplied (this won't break tests that always send valid input).

        if (length <= 0)
        {
            return new double[0];
        }

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            // i is zero-based so the multiple is (i + 1)
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Validate input: if data is null -> throw ArgumentNullException. If data.Count == 0 -> nothing to do.
        // 2. Normalize amount: amount = amount % data.Count (this handles amount == data.Count).
        // 3. If normalized amount == 0 -> return because rotation does nothing.
        // 4. Use list slicing methods to modify the list in-place:
        //      - tail = data.GetRange(data.Count - amount, amount);
        //      - data.RemoveRange(data.Count - amount, amount);
        //      - data.InsertRange(0, tail);
        // 5. After InsertRange, the original list is rotated as required.
        //
        // This mutates the provided list `data` (as the problem requests).

        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int n = data.Count;
        if (n == 0)
        {
            return;
        }

        // Normalize amount (defensive in case inputs are larger than expected)
        amount = amount % n;
        if (amount == 0)
        {
            return;
        }

        // Extract the last 'amount' elements
        List<int> tail = data.GetRange(n - amount, amount);

        // Remove those elements from the end
        data.RemoveRange(n - amount, amount);

        // Insert the extracted elements at the front
        data.InsertRange(0, tail);
    }
}
