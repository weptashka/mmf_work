import React from "react";
import Image from "next/image";
import { BsSearch, BsCameraVideo } from "react-icons/bs";
import {
  SlGameController,
  SlOptionsVertical,
  SlBasket,
  SlMenu,
} from "react-icons/sl";
import {
  IoHomeOutline,
  IoFlagOutline,
  IoMenu,
  IoChatboxEllipses,
  IoNotifications,
  IoChatbubbles,
} from "react-icons/io5";
import { SiGooglemessages } from "react-icons/si";
import { useSession, signOut } from "next-auth/react";

const Header = () => {
  const {data: session} = useSession();
  return (
    <div className="bg-white flex iteams-center p-2 shadow-md top-0 sticky z-50 h-16">
      {/*Left*/}
      <div className="flex min-w-fit">
        <Image className="pt-1 pb-1 m-0.5"
          // src="https://icons.iconarchive.com/icons/chanut/role-playing/128/Spell-Scroll-icon.png"
          src={require("/styles/img/letter-il2.svg")}
          alt="inline logo"
          height={40}
          width={40}
        />
      </div>
      <div className="flex items-center space-x-2 px-2 ml-2 rounded-full bg-gray-100 text-gray-500">
        <BsSearch sixe={20} />
        <input
          className="hidden lg:inline-flex bg-transparent focus:outline-none"
          type="text"
          placeholder="Inline Search"
        />
      </div>
      {/*Center*/}
      <div className="flex flex-grow justify-center mx-2">
        <div className="flex items-center">
          <div className="flex items-center h-14 px-4 md:px-10 rounded-md md:hover:bg-gray-100 cursor-pointer">
            <IoHomeOutline className="mx-auto" size={25} color="black" />
          </div>
          <div className="flex items-center h-14 px-4 md:px-10 rounded-md md:hover:bg-gray-100 cursor-pointer">
            <IoFlagOutline className="mx-auto" size={25} color="black" />
          </div>
          <div className="flex items-center h-14 px-4 md:px-10 rounded-md md:hover:bg-gray-100 cursor-pointer">
            <BsCameraVideo className="mx-auto" size={25} color="black" />
          </div>
          <div className="flex items-center h-14 px-4 md:px-10 rounded-md md:hover:bg-gray-100 cursor-pointer">
            <SlBasket className="mx-auto" size={25} color="black" />
          </div>
          <div className="flex items-center h-14 px-4 md:px-10 rounded-md md:hover:bg-gray-100 cursor-pointer">
            <SlGameController className="mx-auto" size={25} color="black" />
          </div>
        </div>
      </div>
      {/*Right*/}
      <div className="flex items-center justify-end mid-w-fit space-x-2">
        <Image
          onClick={signOut}
          src={session?.user.image}
          alt="inline logo"
          height={40}
          width={40}
          className="rounded-full cursor-pointer"
        />
        <p className="hidden xl:inline-flex font-semibold texr-sm whitespace-nowrap p-3 max-w-xs text-black">
          {session?.user.name.split(" ")[0]}
        </p>
        <IoMenu
          className="hidden lg:inline-flex h-10 w-10 bg-gray-200 text-gray-600 rounded-full p-2 coursor-pointer hover:bg-gray-300"
          size={10}
        />
        <SiGooglemessages
          className="hidden lg:inline-flex h-10 w-10 bg-gray-200 text-gray-600 rounded-full p-2 coursor-pointer hover:bg-gray-300"
          size={20}
        />
        <IoNotifications
          className="hidden lg:inline-flex h-10 w-10 bg-gray-200 text-gray-600 IoNotifications rounded-full p-2 coursor-pointer hover:bg-gray-300"
          size={20}
        />
        <SlOptionsVertical
          className="hidden lg:inline-flex h-10 w-10 bg-gray-200 text-gray-600 rounded-full p-2 coursor-pointer hover:bg-gray-300"
          size={20}
        />
      </div>
    </div>
  );
};
``;
export default Header;
