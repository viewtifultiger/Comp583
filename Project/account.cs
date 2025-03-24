public class account{
    int account_number;
    string name;
    int age;
    string account_type;
    string hospital;
    string [] availableTimes;
    
    public account(int num, string name, int age, string account_type, string hospital = null, string available= null){
        account_number = num;
        this.name = name;
        this.age=age;
        this.account_type = account_type;
        this.hospital = hospital;
        this.availableTimes=available;
    }
    
    public int get_account_number(){
        return account_number;
    }
    public string get_name(){
        return name;
    }
    public int get_age(){
        return age;
    }
    public string get_type(){
        return account_type;
    }
    public string get_hospital(){
        if(hospital!=null){
            return hospital;
        }
    }
    public string get_availableTimes(){
        if(availableTimes!=null){
            return availableTimes;
        }
    }
    public void set_name(string n){
        this.name=n;
    }
    public void set_age(int age){
        this.age = age;
    }
    public void set_hospital(string h){
        if(account_type.equals("doctor")){
            this.hospital=h;
        }
    }
    public void set_availableTimes(string a){
        if(account_type.equals("doctor")){
            this.availableTimes=a;
        }
    }
}