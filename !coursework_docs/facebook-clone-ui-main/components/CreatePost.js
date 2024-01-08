import { React, useState, useRef } from "react";
import Image from "next/image";
import { useSession } from "next-auth/react";
import { HiOutlineVideoCamera } from "react-icons/hi";
import { IoMdPhotos } from "react-icons/io";
import { BsEmojiSmile } from "react-icons/bs";
import { RiDeleteBin6Line } from "react-icons/ri";
import { useDispatch } from "react-redux";
import axios from "axios";
import { addPost } from "../public/src/features/postSlice";

const CreatePost = () => {
  //implementing back to front (and in back it os in PostController.java @CrossOrigin)
  const FACEBOOK_CLONE_URL_ENDPOINT = "http://localhost:9008/api/v1/post";
  const { data: session } = useSession();
  const dispatch = useDispatch(); //чтоб при нажатии отправка файлов шла в слайс (диспатчилась)
  const inputRef = useRef(null);
  const hiddenFileInput = useRef(null);
  const [imageToPost, setImageToPost] = useState(null);

  const handleClick = () => {
    hiddenFileInput.current.click();
  };

  //функция загрузки поста при нажатии
  const handleSubmit = (e) => {
    e.preventDefault();
    if (!inputRef.current.value) return;
    const formData = new FormData();

    formData.append("file", imageToPost);
    console.log("imagetopost: " + imageToPost);
    formData.append("post", inputRef.current.value);
    formData.append("name", session?.user.name);
    formData.append("email", session?.user.email);
    formData.append("profilePic", session?.user.image);

    //при клике, вся инфа о профиле, о контенте поста опубликовывается,посту даётся URL
    //затем респонсом чистится поле для создания постов (текст и/или фото)
    // и можно закетчить ошибку
    axios
      .post(FACEBOOK_CLONE_URL_ENDPOINT, formData, {
        headers: { Accept: "application/json" },
      })
      .then((response) => {
        inputRef.current.value = "";
        dispatch(addPost(response.data));
        console.log(response.data);
        removeImage();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  // картинка появляется в посте
  const addImageToPost = (e) => {
    const reader = new FileReader();
    if (e.target.files[0]) {
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (e) => {
        setImageToPost(e.target.result);
      };
    }
  };

  //картинка удаляется из поста
  const removeImage = () => {
    setImageToPost(null);
  };

  return (
    <div className="bg-white rounded-md shadow-md text-gray-500 p-2">
      <div className="flex p-4 space-x-2 item">
        <Image
          src={session?.user.image}
          alt="inline logo"
          height={40}
          width={40}
          className="rounded-full cursor-pointer"
        />
        <form className="flex flex-1">
          <input
            className="rounded-full h-10 flex-grow focus:outline-none font-regular bg-gray-100 px-4"
            type="text"
            ref={inputRef}
            placeholder={`What's on your mind, ${
              session?.user.name.split(" ")[0]
            }?`}
          ></input>
          <button hidden onClick={handleSubmit}></button>
        </form>
      </div>
      {imageToPost && (
        <div
          onClick={removeImage}
          className="flex items-center px-4 py-2 space-x-4 filter hover:brightness-110 transotion duration-150 cursor pointer"
        >
          <img src={imageToPost} className="h-10 object-contain" />
          <RiDeleteBin6Line className="h-8 hover:text-red-500" />
        </div>
      )}
      <div className="flex justify-evenly py-2">
        <div className="flex items-center p-1 space-x-1 flex-grow justify-center hover:cursor-pointer hover:bg-gray-100 rounded-md">
          <HiOutlineVideoCamera sixe={20} className="text-red-500" />
          <p className="font-regular text-gray-600">Live Video</p>
        </div>
        <div
          onClick={handleClick}
          className="flex items-center p-1 space-x-1 flex-grow justify-center hover:cursor-pointer hover:bg-gray-100 rounded-md">
          <IoMdPhotos className="text-green-500" size={20} />
          <p className="font-semibold text-gray-600">Photo/Video</p>
          <input
            ref={hiddenFileInput}
            onChange={addImageToPost}
            type="file"
            accept="image/*"
            hidden
          />
        </div>
        <div className="flex items-center p-1 space-x-1 flex-grow justify-center hover:cursor-pointer hover:bg-gray-100 rounded-md">
          <BsEmojiSmile sixe={20} className="text-yellow-500" />
          <p className="font-regular text-gray-600">Feeling/Activity</p>
        </div>
      </div>
    </div>
  );
};

export default CreatePost;
