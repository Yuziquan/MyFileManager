using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFileManager
{
    //双向链表节点类(用来存储用户的历史访问路径)
    class DoublyLinkedListNode
    {
        //保存的路径
        private string path;
        private DoublyLinkedListNode preNode = null;
        private DoublyLinkedListNode nextNode = null;

        public string Path { set; get; }
        public DoublyLinkedListNode PreNode { set; get; }
        public DoublyLinkedListNode NextNode { set; get; }

    }
}
