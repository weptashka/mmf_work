package com.inline.facebookcloneservice.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.hibernate.annotations.GenericGenerator;

import jakarta.persistence.*;

@Entity
@Table(name = "posts")
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class PostEntity {

    @Id
    @GeneratedValue(generator = "uuid")
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    private String id;

    @Lob
    private String post;
    private String name;
    private String email;

    @Lob
    private String image;
    private String profilePic;
    private String timeStamp;
    private String imageName;
}




//import jakarta.persistence.*;
//import lombok.AllArgsConstructor;
//import lombok.Builder;
//import lombok.Data;
//import lombok.NoArgsConstructor;
//import org.hibernate.annotations.GenericGenerator;
//
//@Entity
//@Table(name="posts")
//@Data
//@Builder
//@NoArgsConstructor
//@AllArgsConstructor
//public class PostEntity {
//    @Id
//    @GeneratedValue(generator="uuid")
//    @GenericGenerator(name = "uuid", strategy = "uuid2")
//    private String id;
//    @Lob //it's a blob (can store any number of data) (for post because it's can be too big)
//    private String post;
//    private String name;
//    private String email;
//    private String image;
//    @Lob
//    private String profilePic;
//    private String timeStamp;
//}
