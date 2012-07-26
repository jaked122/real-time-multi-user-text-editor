﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLangLib
{
    class VBdotNET:Language
    {
        internal VBdotNET(){
            this.keywords = "AddHandler,AddressOf,Alias,And,AndAlso,Ansi,As,Assembly,Auto,Boolean,ByRef,Byte,ByVal,Call,Case,Catch,CBool,CByte,CChar,CDate,CDec,CDbl,Char,CInt,Class,CLng,CObj,Const,CShort,CSng,CStr,CType,Date,Decimal,Declare,Default,Delegate,Dim,DirectCast,Do,Double,Each,Else,ElseIf,End,Enum,Erase,Error,Event,Exit,False,Finally,For,Friend,Function,Get,GetType,GoSub,GoTo,Handles,If,Implements,Imports,In,Inherits,Integer,Interface,Is,Let,Lib,Like,Long,Loop,Me,Mod,Module,MustInherit,MustOverride,MyBase,MyClass,Namespace,New,Next,Not,Nothing,NotInheritable,NotOverridable,Object,On,Option,Optional,Or,OrElse,Overloads,Overridable,Overrides,ParamArray,Preserve,Private,Property,Protected,Public,RaiseEvent,ReadOnly,ReDim,REM,RemoveHandler,Resume,Return,Select,Set,Shadows,Shared,Short,Single,Static,Step,Stop,String,Structure,Sub,SyncLock,Then,Throw,To,True,Try,TypeOf,Unicode,Until,When,While,With,WithEvents,WriteOnly,Xor".Split(',');
            this.commentChar = "'";
            this.fileExtension = ".vb";
        }
    }
}
