﻿export class SignUpRequest {

    constructor(
        public id = 0,
        public username = "",
        public email = "",
        public password = "",
        public confirmedPassword = "",
        public birthDate = "",
        public gender = "Unknown"
    ) { }

    toString() {
        return JSON.stringify(this);
    }
}