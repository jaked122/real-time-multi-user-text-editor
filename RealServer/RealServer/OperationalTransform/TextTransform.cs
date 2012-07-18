﻿namespace OperationalTransform
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #region Enumerations

    public enum TextTransformType
    {
        Insert,
        Delete,
        Initialize,
        Append
    }

    #endregion Enumerations

    [Serializable]
    public class TextTransformActor : System.Runtime.Serialization.ISerializable
    {
        #region Fields
        //Not for use by the client, but, should be enough
        public DateTime time;

        string insert;
        bool isserver;
        int lengthtodelete;
        TextTransformType _command;
        int _uncompensatedindex;

        #endregion Fields

        #region Constructors

        public TextTransformActor(int index, string data)
        {
            isserver = false;
            this._command = TextTransformType.Insert;
            this._uncompensatedindex = index;
            insert = data;
        }
        /// <summary>
        /// Initialize for appending
        /// </summary>
        /// <param name="appendix">String to append</param>
        /// <param name="dummy">index</param>
        public TextTransformActor(string appendix, int dummy)
        {
            if (dummy <= 0)
            {
                this._command = TextTransformType.Initialize;
            }
            else
            {
                this._command = TextTransformType.Append;
            }
            this._uncompensatedindex= dummy;
            this.insert = appendix;
        }
        public TextTransformActor(string initialization)
        {
            this.insert = initialization;
            this._command = TextTransformType.Initialize;
        }

        public void AlterForClient()
        {
            this.isserver = false;
            this.time = DateTime.Now; 
        }

        public TextTransformActor(int index, int length)
        {
            isserver = false;
            _command = TextTransformType.Delete;
            _uncompensatedindex = index;
            this.lengthtodelete = length;
        }

        #endregion Constructors

        #region Properties

        public TextTransformType Command
        {
            get
            {
                return _command;
            }
        }

        public int Index
        {
            get
            {
                return _uncompensatedindex;
            }
        }

        public string Insert
        {
            get
            {
                return insert;
            }
        }

        //length of modification made
        public int Length
        {
            get
            {
                if (_command == TextTransformType.Insert)
                    return insert.Length;
                else
                    return this.lengthtodelete;
            }
        }
        public bool FromServer 
        { 
            get 
            { 
                return !isserver; 
            } 
        }
        public bool FromClient 
        {
            get 
            { 
                return !isserver; 
            } 
        }
        #endregion Properties

        #region Methods

        public static TextTransformActor GetObjectFromBytes(byte[] q)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter t = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (TextTransformActor)t.Deserialize((System.IO.Stream)new System.IO.MemoryStream(q));
        }

        public static byte[] GetObjectInBytes(TextTransformActor g)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter t = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream y = new System.IO.MemoryStream();
            t.Serialize(y, g);
            byte[] q = new byte[y.Length];
            y.Read(q, 0, (int)y.Length);
            y.Close();
            return q;
        }
        public void AlterforServer()
        {
            this.isserver = true;
            this.time = DateTime.Now;
        }

        /// <summary>
        /// Guess What! It should work
        /// </summary>
        /// <param name="info">Reference object to add information to.</param>
        /// <param name="context">Not a clue</param>
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("Command", (int)this._command);
            info.AddValue("TimeStamp", time.ToBinary());
            if (_command == TextTransformType.Insert)
            {
                info.AddValue("Insert", insert);
            }
            else
            {
                info.AddValue("DeleteLength", this.Length);
            }
            info.AddValue("index", this._uncompensatedindex);
            info.AddValue("isserver", this.isserver);
            info.AddValue("time", time.ToBinary());
        }

        #endregion Methods
    }


}