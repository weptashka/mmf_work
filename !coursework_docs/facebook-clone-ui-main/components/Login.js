import React from "react";
import Image from "next/image";
import { signIn } from "next-auth/react";


const Login = () => {
  return (
    <div className="flex flex-col items-center mx-auto mt-20">
      <Image
        alt="inline logo"
        src={require("/styles/img/letter-il2.svg")}
        height={240}
        width={240}
      />
      <a
        onClick={signIn}
        className="px-20 py-5 z-10 text-2xl cursor-pointer 
        mt-5 bg-blue-500 rounded-md text-white"
      >
        Login
      </a>
    </div>
  );
};

export default Login;
