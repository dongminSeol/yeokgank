export class RegionRequest {
    constructor(
        public page = 1,
        public size = 10,
        public h_cd = "11",
        public m_cd = "",
        public s_cd = "",
        public t_cd = ""
    ) { }
}