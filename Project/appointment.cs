public class appointment{
  string date;
  string time:
  int accountNum;
  string patientName;
  string doctorName;
  string hospitalName;

  public appointment(string d, string t, int num, string patient, string doctor, string hospital){
    date=d;
    time=t;
    accountNum=num;
    patientName=patient;
    doctorName=doctor;
    hospitalName=hospital;
  }  

  public string get_date(){
    return date;
  }
  public string get_time(){
    return time;
  }
  public int get_account(){
    return accountNum;
  }
  public string get_patient(){
    return patientName;
  }
  public string get_doctor(){
    return doctorName;
  }
  public string get_hospital(){
    return hospitalName;
  }

  public void set_date(string d){
    date=d;
  }
  public void set_time(string t){
    time=t;
  }
  public void set_doctor(string doctor){
    doctorName=doctor;
  }
  public void set_hospital(string hospital){
    hospitalName=hospital;    
  }

}