import {
    GetYear
    ,GetMonth
    ,GetDay
  } from "./tradeInfoActions";
  
  export enum TradeInfoActionTypes {
    getMonth,
    getYear,
    getDay
  }
  
  export type TradeInfoAction =
      | GetYear
      | GetMonth
      | GetDay;
   
  