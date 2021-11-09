export class TradeRequest {
    constructor(
        public h_cd = "11",
        public m_cd = "000",
        public s_date = "",
        public e_date = "",
    ) { }
    toString() {
        return JSON.stringify(this);
    }
}