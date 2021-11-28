using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItogRezult : MonoBehaviour
{
    public GameObject[] columnOfCharacteristic;
    public string[] characteristic;
    public Text RezultGeneral;
    public Text RezultLifeStyle;
    public Text RezultStudy;
    public Text EmojiStatus;
    public Text ItogCode;
    public Text TestText;


    //Получаем переменные
    float[] GetallCharacteristic(int devisor,int choice){
        float Dcharacteristic =0;
        for(int i=0; i<devisor; i++){
            Dcharacteristic += PlayerPrefs.GetInt(characteristic[16+i + choice]);
        }
        Dcharacteristic = Dcharacteristic/devisor;
        float DRcharacteristic  =0;
        for(int i=0; i<devisor; i++){
            DRcharacteristic += PlayerPrefs.GetInt(characteristic[20+i+ choice]);
        }
        DRcharacteristic = DRcharacteristic/devisor;
        float ODcharacteristic =0;
        for(int i=0; i<devisor; i++){
            ODcharacteristic += PlayerPrefs.GetInt(characteristic[24+i+ choice]);
        }
        ODcharacteristic = ODcharacteristic/devisor;
        float Ocharacteristic  =0;
        for(int i=0; i<devisor; i++){
            Ocharacteristic += PlayerPrefs.GetInt(characteristic[12+i+choice]);
        }
        Ocharacteristic = Ocharacteristic/devisor;
        float Ccharacteristic  =0;
        for(int i=0; i<devisor; i++){
            Ccharacteristic += PlayerPrefs.GetInt(characteristic[8+i+choice]);
        }
        Ccharacteristic = Ccharacteristic/devisor;
        float Kcharacteristic  =0;
        for(int i=0; i<devisor; i++){
            Kcharacteristic += PlayerPrefs.GetInt(characteristic[4+i+choice]);
        }
        Kcharacteristic = Kcharacteristic/devisor;
        float Pcharacteristic =0;
        for(int i=0; i<devisor; i++){
            Pcharacteristic += PlayerPrefs.GetInt(characteristic[0+i+choice]);
        }
        Pcharacteristic = Pcharacteristic/devisor;
        float[] allCharacteristic = {Pcharacteristic, Kcharacteristic, Ccharacteristic, Ocharacteristic, Dcharacteristic, DRcharacteristic, ODcharacteristic};
        return allCharacteristic;
    }
    //проверка на прогрессивный и регрессивный
    string CheckProgressivRegressiv(float[] allCharacteristic, Text Rezult){
        if((allCharacteristic[4] + allCharacteristic[5] + allCharacteristic[6])-(allCharacteristic[0] + allCharacteristic[1] + allCharacteristic[2]) >= 5){
            Rezult.text += " Прогрессивный";
            return "A";
        }else{
            if((allCharacteristic[0] + allCharacteristic[1] + allCharacteristic[2])-(allCharacteristic[4] + allCharacteristic[5] + allCharacteristic[6]) >= 5){
                Rezult.text += " Регрессивный";
                return "B";
            }else{
                return "";
            }
        }
    }
    //Проверка на Импульсивный, Экстравертивный, Уплошенный
    string CheckImpulsiveExtrovertedFlattened(float[] allCharacteristic, Text Rezult){
        if(CheckProgressivRegressiv(allCharacteristic, Rezult) != ""){
            return "";
        }else{
            int pick=0;
            for(int i =0; i<allCharacteristic.Length; i++){
                switch(i){
                    case 0:
                        if(allCharacteristic[i]-allCharacteristic[i+1]>=4){
                            pick++;
                        }
                        break;
                    case 6:
                        if(allCharacteristic[i]-allCharacteristic[i-1]>=4){
                            pick++;
                        }
                        break;
                    default:
                        if((allCharacteristic[i]-allCharacteristic[i+1]>=2)&&(allCharacteristic[i]-allCharacteristic[i-1]>=2)){
                            pick++;
                        }
                        break;
                } 
            }
            switch(pick){
                case 4:
                    Rezult.text += " Импульсивный";
                    return "C";
                    break;
                case 3:
                    Rezult.text += " Импульсивный";
                    return "C";
                    break;
                case 2:
                    Rezult.text += " Экспрессивный";
                    return "D";
                    break;
                case 1:
                    float sum=0;
                    for(int i =0; i<allCharacteristic.Length; i++){
                        sum+=allCharacteristic[i];
                    }
                    if(sum>=42){
                        Rezult.text += " Уплощенный, мотивационно всеяден";
                        return "F";
                    }else{
                        Rezult.text += " Уплощенный, мотивационно равнодушен";
                        return "G";
                    }
                    break;
                case 0:
                    float sum1=0;
                    for(int i =0; i<allCharacteristic.Length; i++){
                        sum1+=allCharacteristic[i];
                    }
                    if(sum1>=42){
                        Rezult.text += " Уплощенный, мотивационно всеяден";
                        return "F";
                    }else{
                        Rezult.text += " Уплощенный, мотивационно равнодушен";
                        return "G";
                    }
                    break;    
            } 
        }
        return "";

    }

    // проверка на Эмоциональные профили личности
    string CheckEmojiStatus(Text Rezult){
        if((PlayerPrefs.GetInt(characteristic[29])>PlayerPrefs.GetInt(characteristic[28]))&&(PlayerPrefs.GetInt(characteristic[31])>PlayerPrefs.GetInt(characteristic[30]))){
            Rezult.text += " Стенический";
            return "H";
        }
        if((PlayerPrefs.GetInt(characteristic[29])<PlayerPrefs.GetInt(characteristic[28]))&&(PlayerPrefs.GetInt(characteristic[31])<PlayerPrefs.GetInt(characteristic[30]))){
            Rezult.text += " Астенический";
            return "I";
        }
        if((PlayerPrefs.GetInt(characteristic[29])<=PlayerPrefs.GetInt(characteristic[28]))&&(PlayerPrefs.GetInt(characteristic[31])>=PlayerPrefs.GetInt(characteristic[30]))){
            Rezult.text += " Смешанный стенический";
            return "J";
        }
        if((PlayerPrefs.GetInt(characteristic[29])>=PlayerPrefs.GetInt(characteristic[28]))&&(PlayerPrefs.GetInt(characteristic[31])<=PlayerPrefs.GetInt(characteristic[30]))){
            Rezult.text += " Смешанный астенический";
            return "K";
        }
        return "";
    }

    void Start()
    {
        //Выводим график
        for(int i=0; i<columnOfCharacteristic.Length;i++){
            if(PlayerPrefs.HasKey(characteristic[i])){
                columnOfCharacteristic[i].transform.localScale = new Vector3(0.2f, 0.2f * PlayerPrefs.GetInt(characteristic[i]), 0.0f);
                columnOfCharacteristic[i].transform.position += new Vector3(0.0f,(PlayerPrefs.GetInt(characteristic[i]) * 0.2f)/2 - 0.1f,0.0f);
            }else{
                Debug.Log(characteristic[i]);
            }

        } 
        float[] allCharacteristic = GetallCharacteristic(4, 0);
        string code = CheckProgressivRegressiv(allCharacteristic, RezultGeneral);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, RezultGeneral);
        allCharacteristic = GetallCharacteristic(2, 0);
        code += CheckProgressivRegressiv(allCharacteristic, RezultLifeStyle);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, RezultLifeStyle);
        allCharacteristic = GetallCharacteristic(2, 2);
        code += CheckProgressivRegressiv(allCharacteristic, RezultStudy);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, RezultStudy);
        allCharacteristic = GetallCharacteristic(1, 0);
        code += CheckProgressivRegressiv(allCharacteristic, TestText);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, TestText);
        allCharacteristic = GetallCharacteristic(1, 1);
        code += CheckProgressivRegressiv(allCharacteristic, TestText);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, TestText);
        allCharacteristic = GetallCharacteristic(1, 2);
        code += CheckProgressivRegressiv(allCharacteristic, TestText);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, TestText);
        allCharacteristic = GetallCharacteristic(1, 3);
        code += CheckProgressivRegressiv(allCharacteristic, TestText);
        code += CheckImpulsiveExtrovertedFlattened(allCharacteristic, TestText);
        code += CheckEmojiStatus(EmojiStatus);
        for(int i =0; i<32;i++){
            if(PlayerPrefs.GetInt(characteristic[i]) > 9){
                code+="" + PlayerPrefs.GetInt(characteristic[i]);
            }else{
                code+="0" + PlayerPrefs.GetInt(characteristic[i]);
            }
        }
        code+="_"+PlayerPrefs.GetString("FullName") +"_"+PlayerPrefs.GetString("Gender")+ "_"+ PlayerPrefs.GetString("Faculty") + "_" + PlayerPrefs.GetString("Class")+ "_" + PlayerPrefs.GetString("SubClass");
        ItogCode.text = code;
    }
}
