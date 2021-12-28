using UnityEngine;

public class HashData<T>
{
    public string name;
    public T data;

    public HashData(string _name, T _data)
    {
        name = _name;
        data = _data;
    }
}

public class HashTable<T>
{
    public HashData<T>[] hashArray;

    public HashTable(int _size)
    {
        hashArray = new HashData<T>[_size];
    }

    public bool Insert(string _name, T data)
    {
        _name = _name.ToUpper();
        int index = GetIndex(_name);
        int initialIndex = index;
        bool looped = false;

        while (hashArray[index] != null && !looped)
        {
            if (index < hashArray.Length - 1)
            {
                ++index;
            }
            else
            {
                index = 0;
            }

            if (initialIndex == index)
            {
                looped = true;
                return false;
            }
        }

        hashArray[index] = new HashData<T>(_name, data);
        return true;
    }

	public T Search(string _name)
	{
		_name = _name.ToUpper();
		int index = GetIndex(_name);
		int initialIndex = index;
		bool looped = false;

		while (hashArray[index] != null && !looped)
		{
			if (hashArray[index].name == _name)
			{
				
				return hashArray[index].data;
			}

			if (index < hashArray.Length -1)
			{
				++index;
			}
			else
			{
				index = 0;
			}

			if (initialIndex == index)
			{
				looped = true;
			}
		}

		return default;
	}

	public T Search(T _data)
	{
		int index = 0;

		for (int i = 0; i < hashArray.Length; i++)
		{
			if (hashArray[index].Equals(_data))
			{
				return hashArray[index].data;
			}
		}

		return default;
	}

	public HashData<T> Remove(string _name)
    {
        _name = _name.ToUpper();
        int index = GetIndex(_name);
        int initialIndex = index;
        bool looped = false;

        while (hashArray[index] != null && !looped)
        {
            if (hashArray[index].name == _name)
            {
                HashData<T> temp = hashArray[index];

                hashArray[index] = null;
                return temp;
            }

            if (index < hashArray.Length - 1)
            {
                ++index;
            }
            else
            {
                index = 0;
            }

            if (initialIndex == index)
            {
                looped = true;
            }
        }

        return null;
    }

    int GetIndex(string _value)
    {
        int index = 0;

        foreach (char c in _value)
        {
            index += LetterToNumber(c);
        }

        index %= hashArray.Length;

        return index;
    }

    int LetterToNumber(char _letter)
    {
        int num = _letter - 64;

        return num;
    }
}