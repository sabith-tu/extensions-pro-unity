using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SABI
{
    [Serializable]
    public class KeyValue<Key, Value>
    {
        public Key key;
        public Value value;
    }

    [Serializable]
    public class KeyValue<Key, Value, Value2>
    {
        public Key key;
        public Value value1;
        public Value2 value2;
    }

    [Serializable]
    public class KeyValue<Key, Value, Value2, Value3>
    {
        public Key key;
        public Value value1;
        public Value2 value2;
        public Value3 value3;
    }

    [Serializable]
    public class KeyValue<Key, Value, Value2, Value3, Value4>
    {
        public Key key;
        public Value value1;
        public Value2 value2;
        public Value3 value3;
        public Value4 value4;
    }


    [Serializable]
    public class KeyValue<Key, Value, Value2, Value3, Value4, Value5> : IEnumerator, IEnumerable
    {
        public Key key;
        public Value value1;
        public Value2 value2;
        public Value3 value3;
        public Value4 value4;
        public Value5 value5;

        int position = -1;

        public object Current => position switch
        {
            0 => value1,
            1 => value2,
            2 => value3,
            3 => value4,
            4 => value5,
            _ => throw new NotImplementedException()
        };

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public IEnumerator GetEnumerator() => new KeyValue<Key, Value, Value2, Value3, Value4, Value5>()
        {
            key = this.key,
            value1 = this.value1,
            value2 = this.value2,
            value3 = this.value3,
            value4 = this.value4,
            value5 = this.value5,
        };
        // public IEnumerator GetEnumerator() => this;

        public bool MoveNext()
        {
            position++;
            return position <= 4;
        }

        public void Reset() => position = -1;
    }

    // [Serializable]
    // public class KeyValueCollection<Key, Value>
    // {
    //     public List<KeyValue<Key, Value>> items = new();
    //     public Value GetValueFromKey(Key key)
    //     {
    //         return items.ForEach(item => item.key = key);
    //     }
    // }
}