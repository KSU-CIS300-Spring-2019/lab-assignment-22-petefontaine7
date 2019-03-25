/* TrieWithNoChildren.cs
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
    /// TrieWithNoChildren interfaces a trie node for the case of no child nodes.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// This bool tells whether this is the end of a string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// Add adds a string to trie.
        /// </summary>
        /// <param name="s"> s is the string to be added. </param>
        /// <returns> An ITrie is returned. </returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
            return this;
        }

        /// <summary>
        /// Contains checks to see if a string is in a trie.
        /// </summary>
        /// <param name="s"> s is the string to be checked. </param>
        /// <returns> A bool is returned to tell if the string is in the trie. </returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
                return false;
        }
    }
}
