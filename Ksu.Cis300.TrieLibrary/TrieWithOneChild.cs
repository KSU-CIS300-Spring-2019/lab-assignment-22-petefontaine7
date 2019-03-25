/* TrieWithOneChild.cs
 * Author: Peter Fontaine
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// TrieWithOneChild interfaces ITrie for the case of of trie node child.
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// This tells whether a trie node is the end of a string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// This contains the child of a trie node.
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// This is the label of the child of a trie node.
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// This is the constructor for a TrieWithOneChild.
        /// </summary>
        /// <param name="s"> s is the string to be stored in a trie. </param>
        /// <param name="b"> b is the emptystring bool to be passed. </param>
        public TrieWithOneChild(string s, bool b)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                _hasEmptyString = b;
                _childLabel = s[0];
                _child = new TrieWithNoChildren();
                _child = _child.Add(s.Substring(1));
            }
        }

        /// <summary>
        /// Add takes a string and stores it in a trie.
        /// </summary>
        /// <param name="s"> s is the string to be stored. </param>
        /// <returns> An ITrie is returned. </returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] == _childLabel)
            {
                _child = _child.Add(s.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
            }
            return this;
        }

        /// <summary>
        /// Contains checks to see if a string is contained in a trie.
        /// </summary>
        /// <param name="s"> s is the string to be checked. </param>
        /// <returns> A bool is returned to tell if s is in the trie or not. </returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                if (s[0] != _childLabel)
                {
                    return false;
                }
                else
                {
                    return _child.Contains(s.Substring(1));
                }
            }
        }
    }
}
