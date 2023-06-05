using System;

public class Pack
{
    private readonly InventoryItem[] _items;
    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;
    private int _currentCount;
    private float _currentVolume;
    private float _currentWeight;

    public Pack() : this(10, 20, 30) { }

    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        _items = new InventoryItem[maxCount];
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
    }

    public int GetMaxCount()
    {
        return _maxCount;
    }

    public float GetVolume()
    {
        return _currentVolume;
    }

    public float GetWeight()
    {
        return _currentWeight;
    }

    public bool Add(InventoryItem item)
    {
        if (item == null || _currentCount >= _maxCount || _currentWeight + item.GetWeight() > _maxWeight ||
            _currentVolume + item.GetVolume() > _maxVolume)
        {
            return false;
        }

        _items[_currentCount++] = item;
        _currentWeight += item.GetWeight();
        _currentVolume += item.GetVolume();
        return true;
    }

    public string Info()
    {
        string packInfo = "Pack Contents:\n";
        packInfo += $"Current Count: {_currentCount}\n";
        packInfo += $"Max Count: {_maxCount}\n";
        packInfo += $"Current Weight: {_currentWeight}\n";
        packInfo += $"Max Weight: {_maxWeight}\n";
        packInfo += $"Current Volume: {_currentVolume}\n";
        packInfo += $"Max Volume: {_maxVolume}\n";

        if (_currentCount > 0)
        {
            packInfo += "Items:\n";
            for (int i = 0; i < _currentCount; i++)
            {
                packInfo += $"{_items[i].Display()}\n";
            }
        }
        else
        {
            packInfo += "\nNo items in the pack.";
        }

        Console.WriteLine(packInfo);
        return packInfo;
    }

    public override string ToString()
    {
        string packInfo = "The pack capacity:\n";
        bool isFull = _currentCount >= _maxCount && _currentWeight >= _maxWeight && _currentVolume >= _maxVolume;
        packInfo += $"The pack is {(isFull ? "full" : "not full")}, it can still store {_maxCount - _currentCount} more items";
        packInfo += $", the remaining weight capacity is {_maxWeight - _currentWeight} and the remaining volume capacity is {_maxVolume - _currentVolume}";

        return packInfo;
    }

    internal void info()
    {
        throw new NotImplementedException();
    }

    public abstract class InventoryItem
    {
        private readonly float _volume;
        private readonly float _weight;

        protected InventoryItem(float volume, float weight)
        {
            if (volume <= 0f || weight <= 0f)
            {
                throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
            }
            _volume = volume;
            _weight = weight;
        }

        public abstract string Display();

        public float GetVolume()
        {
            return _volume;
        }

        public float GetWeight()
        {
            return _weight;
        }
    }

    public class Arrow : InventoryItem
    {
        public Arrow() : base(0.1f, 0.1f) { }

        public override string Display()
        {
            return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Bow : InventoryItem
    {
        public Bow() : base(2f, 2f) { }

        public override string Display()
        {
            return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Rope : InventoryItem
    {
        public Rope() : base(1f, 3f) { }//yz

        public override string Display()
        {
            return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Water : InventoryItem
    {
        public Water() : base(1.5f, 1.5f) { }

        public override string Display()
        {
            return $"Water with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Food : InventoryItem
    {
        public Food() : base(0.5f, 0.5f) { }

        public override string Display()
        {
            return $"Yummy food with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Sword : InventoryItem
    {
        public Sword() : base(3f, 5f) { }

        public override string Display()
        {
            return $"A sharp sword with weight {GetWeight()} and volume {GetVolume()}";
        }
    }
}



