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

  public get_date(){
    return date;
  }
  public get_time(){
    return time;
  }
  public get_account(){
    return accountNum;
  }
  public get_patient(){
    return patientName;
  }
  public get_doctor(){
    return doctorName;
  }
  public get_hospital(){
    return hospitalName;
  }

  public set_date(string d){
    date=d;
  }
  public set_time(string t){
    time=t;
  }
  public set_doctor(string doctor){
    doctorName=doctor;
  }
  public set_hospital(string hospital){
    hospitalName=hospital;    
  }

}