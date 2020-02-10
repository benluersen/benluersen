using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BusinessLogic
{
    public List<int> MergeSort(List<int> userList)
    {
        if (userList.Count <= 1)
            return userList;

        List<int> front = new List<int>();
        List<int> back = new List<int>();
        int middle = userList.Count / 2;
        for (int i = 0; i < middle; i++)
        {
            front.Add(userList[i]);
        }
        for (int i = middle; i < userList.Count; i++)
        {
            back.Add(userList[i]);
        }
        front = MergeSort(front);
        back = MergeSort(back);
        return FinalMerge(front, back);
    }

    private static List<int> FinalMerge(List<int> front, List<int> back)
    {
        List<int> result = new List<int>();

        while (front.Count > 0 || back.Count > 0)
        {
            if (front.Count > 0 && back.Count > 0)
            {
                if (front.First() <= back.First())
                {
                    result.Add(front.First());
                    front.Remove(front.First());
                }
                else
                {
                    result.Add(back.First());
                    back.Remove(back.First());
                }
            }
            else if (front.Count > 0)
            {
                result.Add(front.First());
                front.Remove(front.First());
            }
            else if (back.Count > 0)
            {
                result.Add(back.First());

                back.Remove(back.First());
            }
        }
        return result;
    }

    public List<int> BubbleSort(List<int> bubbleList)
    {
        int previous;
        for (int i = 0; i <= bubbleList.Count - 2; i++)
        {
            for (int j = 0; j <= bubbleList.Count - 2; j++)
            {
                if (bubbleList[i] > bubbleList[i + 1])
                {
                    previous = bubbleList[i + 1];
                    bubbleList[i + 1] = bubbleList[i];
                    bubbleList[i] = previous;
                }
            }
        }
        return bubbleList;
    }

    public List<int> ParseIntsToList(string input)
    {
        List<int> result = new List<int>();
        return result;
    }

}

