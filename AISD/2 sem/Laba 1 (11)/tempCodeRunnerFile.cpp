for (int i = 0; i < 20; i++)
    {   
        List1.Del(i);
        for (int j = i; j < 20; j++)
        {
            if (rand[i] == rand[j])
                rand[j] = 51;
        }
    }