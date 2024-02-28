'use client'
import { useState } from "react";
export default () => {
    const [showDropDown, SetDropdown] = useState(false);

    return (
        <div className="lg:w-full lg:flex lg:justify-between hidden pl-3 py-3 h-12 align-middle
        text-white bg-[#005b7f]">
            <div className="text-xl">
                Caribbean MT
            </div>
            <div className="flex flex-row">
                <label htmlFor="search">Search:</label>
                <input type="text" name="search" className="mr-2" />
                <div className="relative">
                <div onClick={() => { SetDropdown(!showDropDown) }} className="cursor-pointer mr-3
                bg-white text-black">
                    More options                    
                </div>
                {showDropDown && <div className="absolute min-w-[300px] float-right right-0 top-[31px] dropdownShadow
                bg-white text-black flex flex-col">
                        <div className="p-2 border-b border-b-slate-500">
                            <input type="text" name="q" id="projects-quick-search" 
                            className="border border-slate-500 w-full"/>                        
                        </div>
                        <div className="p-2 border-b border-b-slate-500 flex flex-col">
                            <strong>Recently used</strong>
                            <a title="Caribbean MT" href="/" className="dropdownLinks"><span className="ml-2 ">Caribbean MT</span></a>
                            <a title="PAPE" href="/" className="dropdownLinks"><span className="ml-2 ">PAPE</span></a>
                            <a title="gsi-ICT-Services" href="/" className="dropdownLinks"><span className="ml-2 ">gsi-ICT-Services</span></a>
                            <strong>All Projects</strong>
                            <a title="Caribbean MT" href="/" className="dropdownLinks"><span className="ml-2 ">Caribbean MT</span></a>
                            <a title="PAPE" href="/" className="dropdownLinks"><span className="ml-2 ">PAPE</span></a>                                                
                        </div>
                        <div className="p-2 border-b border-b-slate-500">
                            <a href="/" className="dropdownLinks"><strong>All Projects</strong></a>
                        </div>
                    </div>}
                </div>

            </div>
        </div>
    )
}