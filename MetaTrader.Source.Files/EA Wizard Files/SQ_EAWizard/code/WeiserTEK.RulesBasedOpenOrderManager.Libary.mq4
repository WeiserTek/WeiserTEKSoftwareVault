//+------------------------------------------------------------------------------------------+
//+ WeiserTEK Rules Based Open Order Management System v0.001
//+------------------------------------------------------------------------------------------+
//

int GetTrendFromEMA()
{
   //0 = Consolidation, 1 = Long, -1 = Short
   int trend = directionByIntValue.NeutralIntValue;    
   bool trendLongFound = true;
   bool trendShortFound = true;
   
   //Header
   if(temamam.ThreeEMATrendDirectionDebugFlagOn)
   {
      debugObject.Add
      (
         "\nTHREE EMA TREND DIRECTION\n"
      );
   }    

   for(int shift=1;shift <=3;shift++)
   {
      double EMAShortest = GetEMA(temamam.ThreeEMATrendDirection_Timeframe,temamam.ThreeEMATrendDirection_Shortest,shift);
      double EMAMiddle = GetEMA(temamam.ThreeEMATrendDirection_Timeframe,temamam.ThreeEMATrendDirection_Middle,shift);
      double EMALongest = GetEMA(temamam.ThreeEMATrendDirection_Timeframe,temamam.ThreeEMATrendDirection_Longest,shift);

      //Testing for long
      if(EMAShortest > EMAMiddle)
      {
         if(EMAMiddle > EMALongest)
         {
            trendShortFound = false;
            trendLongFound = trendLongFound && true;
         }
         else
         {
            trendLongFound = false;
         }
      }
      else
      {
         trendLongFound = false;
      }
      
      //Testing for Short
      if(EMAShortest < EMAMiddle)
      {
         if(EMAMiddle < EMALongest)
         {
            trendLongFound = false;
            trendShortFound = trendShortFound && true;
         }
         else
         {
            trendShortFound = false;
         }
      }
      else
      {
         trendShortFound = false;
      }
      
      //Body
      if(temamam.ThreeEMATrendDirectionDebugFlagOn)
      {
         debugObject.Add
         (
            " Shift " + IntegerToString(shift) + " " + 
            " EMA[" + temamam.ThreeEMATrendDirection_Shortest + "]: " + EMAShortest + " " +
            " EMA[" + temamam.ThreeEMATrendDirection_Middle + "]: " + EMAMiddle + " " +
            " EMA[" + temamam.ThreeEMATrendDirection_Longest + "]: " + EMALongest + " " + 
            " Trend Long Found: " + trendLongFound +  
            " Trend Short Found: " + trendShortFound + "\n" 
         );
      }      
   }
   
   //Can't be both directions
   if(trendLongFound && trendShortFound)
   {
      trendLongFound=false;
      trendShortFound=false;
   }
   
   if(trendLongFound){trend=directionByIntValue.LongIntValue;}
   if(trendShortFound){trend=directionByIntValue.ShortIntValue;}
   
   //Footer
   if(temamam.ThreeEMATrendDirectionDebugFlagOn)
   {
      debugObject.Add
      (
         " Timeframe: " + IntegerToString(temamam.ThreeEMATrendDirection_Timeframe) + "\n" 
         " EMA Trend Found: " + trend + "\n"
      );
   }

   return(trend);      
}

double GetEMA(int timeFrame,int maPeriod,int shift)
{
   return(iMA(NULL,timeFrame,maPeriod,0,MODE_EMA,0,shift));
}

//Direction object that can be used throughout application.
class DirectionByIntValue{
   public:
      int LongIntValue;
      int ShortIntValue;
      int NeutralIntValue;
   
   DirectionByIntValue()
   {
      LongIntValue=1;
      ShortIntValue=-1;
      NeutralIntValue=0;
   }
};

//Object Instantiations
//DebugObject debugObject;
//WavePointClusterObject wpco[2000];
//PivotPointObject ppo[2000];
//TriangleBreakoutObject tboo[2000];
DirectionByIntValue directionByIntValue;
//PivotTypes pivotType;
//WaveBreakManager wbm; 
//BreakoutLineObject bolo[2000];
//WaveBreakOrderEntryManager wboem;
TripleEMAMovingAverageManager temamam;
//CurrentBreakoutLinePriceManager cbopm;
//CurrentTriangleBreakoutDirection ctbod;
