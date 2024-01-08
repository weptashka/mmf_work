import React from "react";
import { BiSearch } from "react-icons/bi";
import { RiVideoAddFill } from "react-icons/ri";
import { CgMoreAlt } from "react-icons/cg";
import Contacts from "./Contacts";

export const RightSidebar = () => {
  return (
    <div className="hidden md:inline-flex flex-col pt-4 max-w-xl md:min-w-[200px] lg:min-w-[250px]">
      <div className="flex items-center text-gray-500">
        <p className="flex text-lg font-semibold flex-grow">Contacts</p>
        <div className="flex space-x-1 px-2">
          <div className="rounded-full p-2 hover:bg-gray-200 cursor-pointer">
            <RiVideoAddFill />
          </div>
          <div className="rounded-full p-2 hover:bg-gray-200 cursor-pointer">
            <BiSearch />
          </div>
          <div className="rounded-full p-2 hover:bg-gray-200 cursor-pointer">
            <CgMoreAlt />
          </div>
        </div>
      </div>
      <Contacts
        src="https://images.pexels.com/photos/15045108/pexels-photo-15045108.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        name="Katya Zyeva"
        status="Online"
      />
      <Contacts
        src="https://images.pexels.com/photos/16755396/pexels-photo-16755396.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        name="Egor Ryhockiy"
        status="Online"
      />
      <Contacts
        src="https://images.pexels.com/photos/1271620/pexels-photo-1271620.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        name="Alexey Nagornyy"
        status="Offline"
      />
      <Contacts
        src="https://images.pexels.com/photos/14744773/pexels-photo-14744773.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        name="Alesya Dobrickaya"
        status="Offline"
      />
      <Contacts
        src="https://images.pexels.com/photos/16317517/pexels-photo-16317517.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        name="Isaak Yania"
        status="Online"
      />
    </div>
  );
};
