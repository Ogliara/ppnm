public class genlist<T>{

	public T[] data;

	public T this[int i]{
		get{return data[i];} 
		set{data[i]=value;}
		}
	
	public int size => data.Length;

	public genlist(){data = new T[0];}

	public void add (T item){
		T[] newdata = new T[data.Length + 1];
		for(int i=0; i<data.Length; i++) newdata[i] = data[i];
		newdata[data.Length] = item;
		data = newdata;
		}

	public void remove (int i){
		T[] newdata = new T[data.Length - 1];
		for(int j=0; j<newdata.Length; j++){
			if(j<i) newdata[j] = data[j];
			else newdata[j] = data[j+1];
			}
		data = newdata;
		}


	
}//genlist class
