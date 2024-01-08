import React from "react";
import Image from "next/image";
import { ImUsers } from "react-icons/im";
import { TiGroup } from "react-icons/ti";
import { MdVideoLibrary,MdOutlineWatchLater } from "react-icons/md";
import { AiFillShop } from "react-icons/ai";
import { RiArrowDownSLine } from "react-icons/ri";
import SidebarItem from "./SidebarItem";
import { useSession, signOut } from "next-auth/react";



const Sidebar = () => {
  const{data:session} = useSession();
  return (
    <div className="hidden lg:inline-flex flex-col py-2 pl-2 max-w-xl lg:min-w-[302px]">
      <div className="flex items-center space-x-2 py-3 pl-4 hover:bg-gray-200 rounded-l-xl cursor-pointer">
        <Image
          onClick={signOut}
          src={session?.user.image}
          alt="inline logo"
          height={30}
          width={30}  
          className="rounded-full cursor-pointer"
        />
        <p className="hidden sm:inline-flex font-medium">{session?.user.name}</p>
      </div>
      <SidebarItem Icon={ImUsers} value="Friends"/>
      <SidebarItem Icon={TiGroup} value="Group"/>
      <SidebarItem Icon={AiFillShop} value="Marketplace"/>
      <SidebarItem Icon={MdVideoLibrary} value="Watch"/>
      <SidebarItem Icon={MdOutlineWatchLater} value="Memories"/>
      <SidebarItem Icon={RiArrowDownSLine} value="See More"/>
    </div>
  );
};

export default Sidebar;
