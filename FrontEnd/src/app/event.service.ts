import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class EventService {

  public _setCourse:any;
  public _setCourseData:any;

  private _eventsUrl = "https://localhost:44372/api/course";
  private _specialEventsUrl = "https://localhost:44372/api/enrolledcourse/ListOfCourse/";
  private _specialEventsUrlAddCourse = "https://localhost:44372/api/enrolledcourse";
  private _coursesUrl = "https://localhost:44372/api/enrolledcourse/ListOfCourseMentor/";
  private _deleteCourseUrl = "https://localhost:44372/api/course/";
  private _addCourseUrl = "https://localhost:44372/api/course";
  private _updateCourseUrl = "https://localhost:44372/api/course/";
  private _searchCourseUrl = "https://localhost:44372/api/course/search/";
  private _getUserListUrlAdminFetch = "https://localhost:44372/api/course/usersList";
  private _getMentorListUrlAdminFetch = "https://localhost:44372/api/course/mentorsList";
  private _getMentorListUrl = "https://localhost:44372/api/enrolledcourse";
  private _updateMentorUrl = "https://localhost:44372/api/course/mentorProfile/";
  private _updateStudentUrl = "https://localhost:44372/api/course/studentProfile/";
  private _updateEnrolledCourseUrl = "https://localhost:44372/api/enrolledcourse/ChangeEnrolledCourseStatus/";
  private _blockUserUrl = "https://localhost:44359/api/admin/blockunblock/";
  private _mentorProfileUrl = "https://localhost:44372/api/course/mentorProfile/";
  private _studentProfileUrl = "https://localhost:44372/api/course/studentProfile/";
  constructor(private http: HttpClient) { }

  getEvents() {
    return this.http.get<any>(this._eventsUrl)
  }

  getSpecialEvents(StudentEmail) {
    return this.http.get<any>(this._specialEventsUrl+StudentEmail)
  }

  enrollCourse(user) {
    return this.http.post<any>(this._specialEventsUrlAddCourse, user)
  }
  enrolledEvents() {
    return !!localStorage.getItem('EventToken')    
  }
  getCourses(MentorEmail) {
    return this.http.get<any>(this._coursesUrl+MentorEmail)
  }
  deleteCourse(deleteField){
    return this.http.delete<any>(this._deleteCourseUrl+deleteField)
  }

  setCourse(course){
    this._setCourse = course;
    
  }
  getCourse(){
    return this._setCourse;
  }
  
  registerCourses(course) {
    return this.http.post<any>(this._addCourseUrl, course)
  }

  editCourses(editField,course) {
    return this.http.put<any>(this._updateCourseUrl+editField,course)
  }
  
  searchResult(searchField) {
    //const search = {searchItem: searchField};
   // console.log('eventService: ' + JSON.stringify(searchField))
    return this.http.get<any>(this._searchCourseUrl+searchField);
  }

  getusersListAdmin() {
    return this.http.get<any>(this._getUserListUrlAdminFetch)
  }

  getmentorsListAdmin() {
    return this.http.get<any>(this._getMentorListUrlAdminFetch)
  }

  editMentorDetails(mentorId,mentorUpdatedData) {
    console.log('******'+mentorId+'**********'+JSON.stringify(mentorUpdatedData))
    return this.http.put<any>(this._updateMentorUrl+mentorId,mentorUpdatedData)
  }
  editStudentDetails(studentId,studentUpdatedData) {
    console.log('******'+studentId+'**********'+JSON.stringify(studentUpdatedData))
    return this.http.put<any>(this._updateStudentUrl+studentId,studentUpdatedData)
  }
  getMentorListDetails() {
    return this.http.get<any>(this._getMentorListUrl)
  }

  updateEnrolledCourse(updateCourseId,updateCourseUserName,course) {
    return this.http.put<any>(this._updateEnrolledCourseUrl+updateCourseId+'/'+updateCourseUserName,course)
  }

  public blockById(id) {
    return this.http.get<any>(this._blockUserUrl+id)
      
  }
  
  public unBlockById(id) {
    return this.http.get<any>(this._blockUserUrl+id)
  }

  getMentorDetails(mentorEmail){
    return this.http.get<any>(this._mentorProfileUrl+mentorEmail)
  }
  getStudentDetails(mentorEmail){
    return this.http.get<any>(this._studentProfileUrl+mentorEmail)
  }
}
