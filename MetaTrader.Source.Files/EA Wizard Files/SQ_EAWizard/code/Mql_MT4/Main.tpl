[#ftl]
[#--########################################################################
  Warning! Do not delete this header, it is used by Genetic Builder to get 
  information about this code generator.
  
  <name>Expert Advisor for MetaTrader4 (*.MQ4)</name>
  <id>mt4</id>
  <extensionName>MetaTrader4 Expert Advisor</extensionName>
  <extension>mq4</extension>
  <description>&lt;html&gt;Saves strategy as MetaTrader4 EA.&lt;br/&gt;&lt;br/&gt;
  You should save this file to {MetaTrader installation directory}&lt;strong&gt;/experts&lt;/strong&gt; directory.&lt;/html&gt;</description>
  <importToBuildingBlocks>BBFunctions.inc</importToBuildingBlocks>
#########################################################################--]
[@compress single_line=true]
[#include "../global/Functions.inc"]
[#include "Functions.inc"]
[#include "BuildingBlocks.inc"]
[/@compress]
[#if !globalContainsRules()][#stop "Strategy doesn't contain any complete rule"][/#if]
//+------------------------------------------------------------------+
//| ${globalGetOptions("StrategyName")} EA
//|
//|    Generated by StrategyQuant EA Wizard version ${globalGetOptions("ProgramVersion")}
//|    Generated at ${globalGetOptions("Date")}
//+------------------------------------------------------------------+
#property copyright "StrategyQuant.com"
#property link      "http://www.StrategyQuant.com"

#define PATTERN_DOJI 1
#define PATTERN_HAMMER 2
#define PATTERN_SHOOTING_STAR 3
#define PATTERN_DARK_CLOUD 4
#define PATTERN_PIERCING_LINE 5
#define PATTERN_BEARISH_ENGULFING 6
#define PATTERN_BULLISH_ENGULFING 7
#define PATTERN_BEARISH_HARAMI 8
#define PATTERN_BULLISH_HARAMI 9
#define PATTERN_BEARISH_HARAMI_CROSS 10
#define PATTERN_BULLISH_HARAMI_CROSS 11



//+------------------------------------------------------------------+
// -- Variables
//+------------------------------------------------------------------+
[@mq4PrintVariables /]

[#--########################################################################
//+------------------------------------------------------------------+
// -- Trading Parameters
//+------------------------------------------------------------------+
extern string __s8 = "-----  Trading Date Parameters  ---------------";
extern bool TradeSunday = false;
extern bool TradeMonday = true;
extern bool TradeTuesday = true;
extern bool TradeWednesday = true;
extern bool TradeThursday = true;
extern bool TradeFriday = true;
extern bool TradeSaturday = false;
#########################################################################--]
extern bool SupportECNBrokers = true;
extern bool DisplayInfoPanel = true;


//+------------------------------------------------------------------+
// -- Other Hidden Parameters
//+------------------------------------------------------------------+
bool writeInfoMessagesToLog = false;
double gPointPow = 0;
double gPointCoef = 0;
int lastHistoryPosChecked = 0;
int lastHistoryPosCheckedNT = 0;
string currentTime = "";
string lastTime = "";
double brokerStopDifference = 0;
string sqLastPeriod;
bool sqIsBarOpen;
int signalShift = 0;

int LabelCorner = 1;
int OffsetHorizontal = 5;
int OffsetVertical = 20;
color LabelColor = Black;
int lastOrderErrorCloseTime = 0;

//+------------------------------------------------------------------+
// -- Functions
//+------------------------------------------------------------------+

int init() {
   VerboseLog("--------------------------------------------------------");
   VerboseLog("Starting the EA");

   double realDigits = Digits;
   if(realDigits > 0 && realDigits != 2 && realDigits != 4) {
      realDigits -= 1;
   }

   gPointPow = MathPow(10, realDigits);
   gPointCoef = 1/gPointPow;

   VerboseLog("Broker Stop Difference: ",DoubleToStr(brokerStopDifference*gPointPow, 2));

   VerboseLog("--------------------------------------------------------");

   if(DisplayInfoPanel) {
      ObjectCreate("line1", OBJ_LABEL, 0, 0, 0);
      ObjectSet("line1", OBJPROP_CORNER, LabelCorner);
      ObjectSet("line1", OBJPROP_YDISTANCE, OffsetVertical + 0 );
      ObjectSet("line1", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("line1", "${globalGetOptions("StrategyName")} EA", 9, "Tahoma", LabelColor);

      ObjectCreate("linec", OBJ_LABEL, 0, 0, 0);
      ObjectSet("linec", OBJPROP_CORNER, LabelCorner);
      ObjectSet("linec", OBJPROP_YDISTANCE, OffsetVertical + 16 );
      ObjectSet("linec", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("linec", "Generated by StrategyQuant EA Wizard", 8, "Tahoma", LabelColor);

      ObjectCreate("line2", OBJ_LABEL, 0, 0, 0);
      ObjectSet("line2", OBJPROP_CORNER, LabelCorner);
      ObjectSet("line2", OBJPROP_YDISTANCE, OffsetVertical + 28);
      ObjectSet("line2", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("line2", "------------------------------------------", 8, "Tahoma", LabelColor);

      ObjectCreate("lines", OBJ_LABEL, 0, 0, 0);
      ObjectSet("lines", OBJPROP_CORNER, LabelCorner);
      ObjectSet("lines", OBJPROP_YDISTANCE, OffsetVertical + 44);
      ObjectSet("lines", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("lines", "Last Signal:  -", 9, "Tahoma", LabelColor);

      ObjectCreate("lineopl", OBJ_LABEL, 0, 0, 0);
      ObjectSet("lineopl", OBJPROP_CORNER, LabelCorner);
      ObjectSet("lineopl", OBJPROP_YDISTANCE, OffsetVertical + 60);
      ObjectSet("lineopl", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("lineopl", "Open P/L: -", 8, "Tahoma", LabelColor);

      ObjectCreate("linea", OBJ_LABEL, 0, 0, 0);
      ObjectSet("linea", OBJPROP_CORNER, LabelCorner);
      ObjectSet("linea", OBJPROP_YDISTANCE, OffsetVertical + 76);
      ObjectSet("linea", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("linea", "Account Balance: -", 8, "Tahoma", LabelColor);

      ObjectCreate("lineto", OBJ_LABEL, 0, 0, 0);
      ObjectSet("lineto", OBJPROP_CORNER, LabelCorner);
      ObjectSet("lineto", OBJPROP_YDISTANCE, OffsetVertical + 92);
      ObjectSet("lineto", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("lineto", "Total profits/losses so far: -/-", 8, "Tahoma", LabelColor);

      ObjectCreate("linetp", OBJ_LABEL, 0, 0, 0);
      ObjectSet("linetp", OBJPROP_CORNER, LabelCorner);
      ObjectSet("linetp", OBJPROP_YDISTANCE, OffsetVertical + 108);
      ObjectSet("linetp", OBJPROP_XDISTANCE, OffsetHorizontal);
      ObjectSetText("linetp", "Total P/L so far: -", 8, "Tahoma", LabelColor);
   }

   return(0);
}

//+------------------------------------------------------------------+

int deinit() {
   ObjectDelete("line1");
   ObjectDelete("linec");
   ObjectDelete("line2");
   ObjectDelete("lines");
   ObjectDelete("lineopl");
   ObjectDelete("linea");
   ObjectDelete("lineto");
   ObjectDelete("linetp");
   return(0);
}

//+------------------------------------------------------------------+

int start() {
   if(Bars<30) {
      if(writeInfoMessagesToLog) Print("NOT ENOUGH DATA: Less Bars than 30");
      return(0);
   }

   string currentPeriod = sqGetPeriodAsStr();
   if(currentPeriod == sqLastPeriod) {
      sqIsBarOpen = false;
   } else {
      sqLastPeriod = currentPeriod;
      sqIsBarOpen = true;
   }

   sqTextFillOpens();
   if(sqIsBarOpen) {
      sqTextFillTotals();
   }

   manageOrders();

[#list doc.StrategyFile.Strategy.* as tradingRule]
[@mq4PrintTradingRule tradingRule /]
[/#list]

   return(0);
}

//+------------------------------------------------------------------+

void manageOrders() {
   for(int i=OrdersTotal()-1; i>=0; i--) {
      if (OrderSelect(i,SELECT_BY_POS)==true) {
         manageOrder(OrderMagicNumber());

         if(sqIsBarOpen) {
            manageOrderExpiration(OrderMagicNumber());
         }
      }

      if(OrdersTotal() <= 0) return;
   }
}

//----------------------------------------------------------------------------

void manageOrder(int orderMagicNumber) {
   double tempValue = 0;
   double tempValue2 = 0;
   double newSL = 0;
   double plValue = 0;
   int error;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
         [@mq4PrintManageOrder node /]
         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]
}

[#macro mq4PrintManageOrder node]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      if(OrderType() == OP_BUY || OrderType() == OP_SELL) {
         // handle only active orders

         // Trailing Stop
         tempValue = getOrderTrailingStop([@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /], OrderType(), OrderOpenPrice());
         if(tempValue > 0) {
            tempValue2 = getOrderTrailingStopActivation([@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]);

            if(OrderType() == OP_BUY) {
               plValue = Bid - OrderOpenPrice();
               newSL = tempValue;

               if (plValue >= tempValue2 && (OrderStopLoss() == 0 || OrderStopLoss() < newSL) && !sqDoublesAreEqual(OrderStopLoss(), newSL)) {
                  Verbose("Moving trailing stop for order with ticket: ", OrderTicket(), ", Magic Number: ", orderMagicNumber, " to :", newSL);
                  if(!OrderModify(OrderTicket(), OrderOpenPrice(), newSL, OrderTakeProfit(), 0)) {
                     error = GetLastError();
                     Verbose("Failed, error: ", error, " - ", ErrorDescription(error));
                  }
               }
            } else { // OrderType() == OP_SELL
               plValue = OrderOpenPrice() - Ask;
               newSL = tempValue;

               if (plValue >= tempValue2 && (OrderStopLoss() == 0 || OrderStopLoss() > newSL) && !sqDoublesAreEqual(OrderStopLoss(), newSL)) {
                  Verbose("Moving trailing stop for order with ticket: ", OrderTicket(), ", Magic Number: ", orderMagicNumber, " to :", newSL);
                  if(!OrderModify(OrderTicket(), OrderOpenPrice(), newSL, OrderTakeProfit(), 0)) {
                     error = GetLastError();
                     Verbose("Failed, error: ", error, " - ", ErrorDescription(error),", Ask: ", Ask, ", Bid: ", Bid, " Current SL: ",  OrderStopLoss());
                  }
               }
            }
         }

         // Move Stop Loss to Break Even
         tempValue = getOrderBreakEven([@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /], OrderType(), OrderOpenPrice());
         tempValue2 = getOrderBreakEvenAddPips([@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]);
         if(tempValue > 0) {
            if(OrderType() == OP_BUY) {
               newSL = OrderOpenPrice() + tempValue2;
               if (OrderOpenPrice() <= tempValue && (OrderStopLoss() == 0 || OrderStopLoss() < newSL) && !sqDoublesAreEqual(OrderStopLoss(), newSL)) {
                  Verbose("Moving SL 2 BE for order with ticket: ", OrderTicket(), ", Magic Number: ", orderMagicNumber, " to :", newSL);
                  if(!OrderModify(OrderTicket(), OrderOpenPrice(), newSL, OrderTakeProfit(), 0)) {
                     error = GetLastError();
                     Verbose("Failed, error: ", error, " - ", ErrorDescription(error),", Ask: ", Ask, ", Bid: ", Bid, " Current SL: ",  OrderStopLoss());
                  }
               }
            } else { // OrderType() == OP_SELL
               newSL = OrderOpenPrice() - tempValue2;
               if (OrderOpenPrice() >= tempValue && (OrderStopLoss() == 0 || OrderStopLoss() > newSL) && !sqDoublesAreEqual(OrderStopLoss(), newSL)) {
                  Verbose("Moving SL 2 BE for order with ticket: ", OrderTicket(), ", Magic Number: ", orderMagicNumber, " to :", newSL);
                  if(!OrderModify(OrderTicket(), OrderOpenPrice(), newSL, OrderTakeProfit(), 0)) {
                     error = GetLastError();
                     Verbose("Failed, error: ", error, " - ", ErrorDescription(error),", Ask: ", Ask, ", Bid: ", Bid, " Current SL: ",  OrderStopLoss());
                  }
               }
            }
         }

         // Exit After X Bars
         tempValue = getOrderExitAfterXBars([@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]);
         if(tempValue > 0) {
            if (sqGetOpenBarsForOrder(tempValue+10) >= tempValue) {
               Verbose("Exit After ", tempValue, "bars - closing order with ticket: ", OrderTicket(), ", Magic Number: ", orderMagicNumber);
               sqClosePositionAtMarket(-1);
            }
         }
      }
   }

[/#macro]

//----------------------------------------------------------------------------

void manageOrderExpiration(int orderMagicNumber) {
   int tempValue = 0;
   int barsOpen = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
         [@mq4PrintManageOrderExpiration node /]
         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]
}

//----------------------------------------------------------------------------

[#macro mq4PrintManageOrderExpiration node]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      if(OrderType() != OP_BUY && OrderType() != OP_SELL) {
         // handle only pending orders

         // Stop/Limit Order Expiration
         tempValue = getOrderExpiration([@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]);
         if(tempValue > 0) {
            barsOpen = sqGetOpenBarsForOrder(tempValue+10);
            if(barsOpen >= tempValue) {
               Verbose("Order with ticket: ", OrderTicket(), ", Magic Number: ", orderMagicNumber," expired");
               OrderDelete(OrderTicket());
            }
         }
      }
   }

[/#macro]

double getOrderSize(int orderMagicNumber, int orderType) {
   double size = 0;
[#assign mmNode = globalGetOptions("MoneyManagement") /]
[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      size = [@mq4PrintSize node /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(size);
}

//----------------------------------------------------------------------------

double sqGetAverage(int avgIndiNumber, int period, int maMethod, int signalShiftLocal) {
[#assign keys = avgIndicatorsHash?keys]

   double indicatorValue[1000];

   for(int i=0; i<period; i++) {
[#list keys as key]
   [#if key != "empty"]
      if(avgIndiNumber == ${key}) {
         indicatorValue[i] = ${avgIndicatorsHash[key]};
      }
   [/#if]
[/#list]
   }

   double maValue = iMAOnArray(indicatorValue, period, period, 0, maMethod, 0);

   return(maValue);
}


//----------------------------------------------------------------------------

double getOrderPrice(int orderMagicNumber) {
   double price = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
         [@mq4PrintOrderPrice node /]
   }
         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(price, Digits));
}

//----------------------------------------------------------------------------

double getOrderStopLoss(int orderMagicNumber, int orderType, double price) {
   double value = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      [@globalPrintOrderStopLimitRealTotalPrice node "_STOP_LOSS_" "SL" /]
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(value, Digits));
}

//----------------------------------------------------------------------------

double getOrderProfitTarget(int orderMagicNumber, int orderType, double price) {
   double value = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      [@globalPrintOrderStopLimitRealTotalPrice node "_PROFIT_TARGET_" "PT" /]
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(value, Digits));
}

//----------------------------------------------------------------------------

double getOrderExitAfterXBars(int orderMagicNumber) {
   double price = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      price = [@globalPrintOrderSimpleNumber node "_EXIT_AFTER_X_BARS_" /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(price, Digits));
}

//----------------------------------------------------------------------------

double getStopDifferencePrice(int orderMagicNumber) {
   double price = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      price = [@globalPrintOrderSimpleNumber node "_MIN_STOP_DIFF_" /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(price, Digits));
}

//----------------------------------------------------------------------------

double getOrderTrailingStop(int orderMagicNumber, int orderType, double price) {
   double value = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      [@globalPrintOrderStopLimitRealTotalTrailingPrice node "_TRAILING_STOP_" "TS" /]
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(value, Digits));
}

//----------------------------------------------------------------------------

double getOrderTrailingStopActivation(int orderMagicNumber) {
   double value = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      value = [@globalPrintOrderStopLimitPrice node "_TS_ACTIVATION_LEVEL_" /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(value, Digits));
}

//----------------------------------------------------------------------------

double getOrderBreakEven(int orderMagicNumber, int orderType, double price) {
   double value = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
[@globalPrintOrderStopLimitRealTotalTrailingPrice node "_MOVE_SL_TO_BE_" "SL" /]
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(value, Digits));
}

//----------------------------------------------------------------------------

double getOrderBreakEvenAddPips(int orderMagicNumber) {
   double value = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      value = [@globalPrintOrderStopLimitPrice node "_BE_ADD_PIPS_" /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(value, Digits));
}

//----------------------------------------------------------------------------

double getOrderExpiration(int orderMagicNumber) {
   double price = 0;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      price = [@globalPrintOrderSimpleNumber node "_BARS_VALID_" /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(NormalizeDouble(price, Digits));
}

//----------------------------------------------------------------------------

bool getReplaceStopLimitOrder(int orderMagicNumber) {
   bool value = false;

[#list doc.StrategyFile.Strategy.* as tradingRule]
   [#if globalHasIfBlock(tradingRule)]
      [#list tradingRule.Then.* as node]
         [#if globalItIsEntryNode(node)]
   if(orderMagicNumber == [@mq4PrintSLPTSimpleNode node "_MAGIC_NUMBER_" /]) {
      value = [@globalPrintOrderSimpleNumber node "_REPLACE_EXISTING_" /];
   }

         [/#if]
      [/#list]
   [#else]
   !! no rules defined
   [/#if]
[/#list]

   return(value);
}

[#include "MT4Functions.inc"]
[#include "MMFunctions.inc"]
[#include "../WeiserTEK.RulesBasedOpenOrderManager.Libary.mq4"]