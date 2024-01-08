import React from 'react'
import { ImUsers } from "react-icons/im";


const SidebarItem = ({Icon, value}) => {
  return (
    <div className="flex items-center space-x-2 py-3 pl-4 hover:bg-gray-200 rouded-l-xl cursor-poiter">
    <Icon className="h-8 w-8" color="0077FF" />
    <p className="hidden sm:inline-flex text-medium">{value}</p>
  </div>
  )
}

export default SidebarItem