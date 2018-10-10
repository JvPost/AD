using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Interfaces
{
	public interface Iterable<T>
	{
		Iterator<T> Iterator(int position);
	}
}
