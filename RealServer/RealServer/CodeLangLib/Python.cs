﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace CodeLangLib
{
    class Python:Language
    {
        public string[] builtInFunctions = "abs,divmod,input,open,staticmethod,all,enumerate,int,ord,str,any,eval,isinstance,pow,sum,basestring,execfile,issubclass,print,super,bin,file,iter,property,tuple,bool,filter,len,range,type,bytearray,float,list,raw_input,unichr,callable,format,locals,reduce,unicode,chr,frozenset,long,reload,vars,classmethod,getattr,map,repr,xrange,cmp,globals,max,reversed,zip,compile,hasattr,memoryview,round,__import__,complex,hash,min,set,apply,delattr,help,next,setattr,buffer,dict,hex,object,slice,coerce,dir,id,oct,sorted,intern".Split(',');
        public Color builtInFunctionColor = Color.MediumPurple;
        internal Python(){
            this.keywords = "and,del,from,not,while,as,elif,global,or,with,assert,else,if,pass,yield,break,except,import,print,class,exec,in,raise,continue,finally,is,return,def,for,lambda,try".Split(',');
            this.keywordColor = Color.Yellow;
            this.commentChar = "#";
            this.commentColor = Color.Red;
            this.stringColor = Color.SeaGreen;
            this.fileExtension = ".py";
        }
    }
}
